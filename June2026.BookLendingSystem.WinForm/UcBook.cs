using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Books;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class UcBook : UserControl
    {
        private List<BookViewModel> _allBooks = new List<BookViewModel>();
        private readonly BookHttpClientService _bookService = new BookHttpClientService();

        private int _currentPage = 1;
        private const int _pageSize = 10;
        private int _totalPages = 1;

        public UcBook()
        {
            InitializeComponent();
            txtBooksSearch.TextChanged += txtBooksSearch_TextChanged;
            dgvBooks.CellClick += dgvBooks_CellClick;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
        }

        public async Task LoadBooksDataAsync()
        {
            _allBooks = await _bookService.ReadAsync();
            _currentPage = 1; // Reset to page 1 on fresh load
            FilterBooksLocal();
        }

        private void FilterBooksLocal()
        {
            string keyword = txtBooksSearch.Text.Trim();
            var filtered = _allBooks;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = _allBooks.Where(b =>
                    (b.Title != null && b.Title.StartsWith(keyword, System.StringComparison.OrdinalIgnoreCase)) ||
                    (b.Author != null && b.Author.StartsWith(keyword, System.StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            int totalRecords = filtered.Count;
            _totalPages = (int)Math.Ceiling((double)totalRecords / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = 1;

            var pageData = filtered.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            dgvBooks.DataSource = null;
            dgvBooks.DataSource = pageData;

            GridHelper.EnsureSrColumn(dgvBooks, _currentPage, _pageSize);
            EnsureGridActionColumns(dgvBooks);

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
                FilterBooksLocal();
            }
        }

        private void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                FilterBooksLocal();
            }
        }

        private void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                FilterBooksLocal();
            }
        }

        private void txtBooksSearch_TextChanged(object? sender, EventArgs e)
        {
            _currentPage = 1; // Reset to page 1 on search key change
            FilterBooksLocal();
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

        private async void btnBooksRefresh_Click(object sender, EventArgs e)
        {
            await LoadBooksDataAsync();
        }

        private async void btnBooksAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new FrmBookDialog("Add New Book"))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.BookTitle) || string.IsNullOrWhiteSpace(dialog.Author))
                    {
                        MessageBox.Show("Book Title and Author are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var book = new BookViewModel
                    {
                        Title = dialog.BookTitle,
                        Author = dialog.Author,
                        Publisher = string.IsNullOrWhiteSpace(dialog.Publisher) ? null : dialog.Publisher,
                        Category = string.IsNullOrWhiteSpace(dialog.Category) ? null : dialog.Category
                    };

                    await _bookService.CreateAsync(book);
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadBooksDataAsync();
                }
            }
        }

        private async void dgvBooks_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender!;
            if (dgv.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                var book = (BookViewModel)dgv.Rows[e.RowIndex].DataBoundItem;
                var cellBounds = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var relativeX = dgv.PointToClient(Cursor.Position).X - cellBounds.Left;

                if (relativeX < cellBounds.Width / 2)
                {
                    // Edit (✏️)
                    using (var dialog = new FrmBookDialog("Edit Book Settings", book.Title, book.Author, book.Publisher ?? "", book.Category ?? ""))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrWhiteSpace(dialog.BookTitle) || string.IsNullOrWhiteSpace(dialog.Author))
                            {
                                MessageBox.Show("Book Title and Author are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            book.Title = dialog.BookTitle;
                            book.Author = dialog.Author;
                            book.Publisher = string.IsNullOrWhiteSpace(dialog.Publisher) ? null : dialog.Publisher;
                            book.Category = string.IsNullOrWhiteSpace(dialog.Category) ? null : dialog.Category;

                            await _bookService.UpdateAsync(book);
                            MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadBooksDataAsync();
                        }
                    }
                }
                else
                {
                    // Delete (❌)
                    var confirm = MessageBox.Show($"Are you sure you want to soft delete '{book.Title}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        await _bookService.DeleteAsync(book.BookId);
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadBooksDataAsync();
                    }
                }
            }
        }
    }
}
