using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Microsoft.Data.SqlClient;
using June2026.BookLendingSystem.ConsoleApp.Features.BookCopies;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class UcCopy : UserControl
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        private List<BookCopyViewModel> _allCopies = new List<BookCopyViewModel>();
        private readonly BookCopyHttpClientService _copyService = new BookCopyHttpClientService();

        private int _currentPage = 1;
        private const int _pageSize = 10;
        private int _totalPages = 1;

        public UcCopy()
        {
            InitializeComponent();
            txtCopiesSearch.TextChanged += txtCopiesSearch_TextChanged;
            dgvCopies.CellClick += dgvCopies_CellClick;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
        }

        public async Task LoadCopiesDataAsync()
        {
            _allCopies = await _copyService.ReadAsync();
            _currentPage = 1; // Reset to page 1 on fresh load
            FilterCopiesLocal();
        }

        private void FilterCopiesLocal()
        {
            string keyword = txtCopiesSearch.Text.Trim();
            var filtered = _allCopies;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = _allCopies.Where(c =>
                    (c.CopyId != null && c.CopyId.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (c.BookTitle != null && c.BookTitle.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            int totalRecords = filtered.Count;
            _totalPages = (int)Math.Ceiling((double)totalRecords / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = 1;

            var pageData = filtered.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            dgvCopies.DataSource = null;
            dgvCopies.DataSource = pageData;

            GridHelper.EnsureSrColumn(dgvCopies, _currentPage, _pageSize);
            EnsureGridActionColumns(dgvCopies);

            // Update Pagination UI
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            lblTotalCount.Text = $"Total: {totalRecords} records";
            btnPrev.Enabled = (_currentPage > 1);
            btnNext.Enabled = (_currentPage < _totalPages);

            pnlPageNumbers.Controls.Clear();
            for (int i = 1; i <= _totalPages; i++)
            {
                var pageBtn = new Button
                {
                    Text = i.ToString(),
                    Width = 35,
                    Height = 25,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = (i == _currentPage) ? System.Drawing.Color.FromArgb(37, 99, 235) : System.Drawing.Color.White,
                    ForeColor = (i == _currentPage) ? System.Drawing.Color.White : System.Drawing.Color.Black,
                    Tag = i
                };
                pageBtn.FlatAppearance.BorderSize = 1;
                pageBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
                pageBtn.Click += PageBtn_Click;
                pnlPageNumbers.Controls.Add(pageBtn);
            }
        }

        private void PageBtn_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int pageNum)
            {
                _currentPage = pageNum;
                FilterCopiesLocal();
            }
        }

        private void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                FilterCopiesLocal();
            }
        }

        private void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                FilterCopiesLocal();
            }
        }

        private void txtCopiesSearch_TextChanged(object? sender, EventArgs e)
        {
            _currentPage = 1; // Reset to page 1 on search key change
            FilterCopiesLocal();
        }

        private void EnsureGridActionColumns(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("ActionCol"))
            {
                var actionCol = new DataGridViewTextBoxColumn
                {
                    Name = "ActionCol",
                    HeaderText = "Actions",
                    Width = 80,
                    ReadOnly = true
                };
                actionCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                actionCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns.Add(actionCol);
            }

            // Force display index to the end
            dgv.Columns["ActionCol"].DisplayIndex = dgv.Columns.Count - 1;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["ActionCol"].Value = "✏️   🗑️";
            }
        }

        private async void btnCopiesRefresh_Click(object sender, EventArgs e)
        {
            await LoadCopiesDataAsync();
        }

        private async void btnCopiesAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new FrmCopyDialog("Add Book Copy"))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.BookTitle))
                    {
                        MessageBox.Show("Please enter a Book Title.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int? bookId = null;
                    using (IDbConnection db = new SqlConnection(sb.ConnectionString))
                    {
                        bookId = await db.QueryFirstOrDefaultAsync<int?>("SELECT book_id FROM Books WHERE title = @Title AND del_flg = 0", new { Title = dialog.BookTitle });
                    }

                    if (!bookId.HasValue)
                    {
                        MessageBox.Show($"Book with title '{dialog.BookTitle}' not found or is deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var copy = new BookCopyViewModel
                    {
                        CopyId = $"CC-COPY-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}",
                        BookId = bookId.Value,
                        BookCopyCount = string.IsNullOrWhiteSpace(dialog.CopyCount) ? "1" : dialog.CopyCount
                    };

                    await _copyService.CreateAsync(copy);
                    MessageBox.Show("Book copy added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCopiesDataAsync();
                }
            }
        }

        private async void dgvCopies_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender!;
            if (dgv.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                var copy = (BookCopyViewModel)dgv.Rows[e.RowIndex].DataBoundItem;
                var cellBounds = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var relativeX = dgv.PointToClient(Cursor.Position).X - cellBounds.Left;

                if (relativeX < cellBounds.Width / 2)
                {
                    // Edit (✏️)
                    using (var dialog = new FrmCopyDialog("Edit Book Copy Settings", copy.BookTitle ?? "", copy.BookCopyCount))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrWhiteSpace(dialog.BookTitle))
                            {
                                MessageBox.Show("Please enter a Book Title.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            int? bookId = null;
                            using (IDbConnection db = new SqlConnection(sb.ConnectionString))
                            {
                                bookId = await db.QueryFirstOrDefaultAsync<int?>("SELECT book_id FROM Books WHERE title = @Title AND del_flg = 0", new { Title = dialog.BookTitle });
                            }

                            if (!bookId.HasValue)
                            {
                                MessageBox.Show($"Book with title '{dialog.BookTitle}' not found or is deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            copy.BookId = bookId.Value;
                            copy.BookCopyCount = string.IsNullOrWhiteSpace(dialog.CopyCount) ? "1" : dialog.CopyCount;

                            await _copyService.UpdateAsync(copy);
                            MessageBox.Show("Book copy updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadCopiesDataAsync();
                        }
                    }
                }
                else
                {
                    // Delete (❌)
                    var confirm = MessageBox.Show($"Are you sure you want to soft delete copy ID '{copy.CopyId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        bool success = await _copyService.DeleteAsync(copy.CopyId);
                        MessageBox.Show(success ? "Book copy deleted successfully!" : "Failed to delete copy.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadCopiesDataAsync();
                    }
                }
            }
        }
    }
}
