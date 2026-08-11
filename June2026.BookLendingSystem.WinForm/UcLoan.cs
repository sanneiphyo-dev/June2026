using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class UcLoan : UserControl
    {
        private List<BorrowTransactionViewModel> _allTransactions = new List<BorrowTransactionViewModel>();
        private readonly BorrowTransactionHttpClientService _txnService = new BorrowTransactionHttpClientService();

        private int _currentPage = 1;
        private const int _pageSize = 10;
        private int _totalPages = 1;

        public UcLoan()
        {
            InitializeComponent();
            txtTxnMemberId.TextChanged += txtTxnMemberId_TextChanged;
            dgvTransactions.CellClick += dgvTransactions_CellClick;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
        }

        public async Task LoadTransactionsDataAsync()
        {
            _allTransactions = await _txnService.ReadAsync();
            _currentPage = 1; // Reset to page 1 on fresh load
            FilterTransactionsLocal();
        }

        private void FilterTransactionsLocal()
        {
            string keyword = txtTxnMemberId.Text.Trim();
            var filtered = _allTransactions;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = _allTransactions.Where(t =>
                    (t.MemberId != null && t.MemberId.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (t.MemberName != null && t.MemberName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (t.BookTitle != null && t.BookTitle.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            int totalRecords = filtered.Count;
            _totalPages = (int)Math.Ceiling((double)totalRecords / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = 1;

            var pageData = filtered.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = pageData;

            if (dgvTransactions.Columns["MemberId"] != null)
            {
                dgvTransactions.Columns["MemberId"].HeaderText = "Member ID";
            }
            if (dgvTransactions.Columns["MemberName"] != null)
            {
                dgvTransactions.Columns["MemberName"].HeaderText = "Member Name";
            }
            if (dgvTransactions.Columns["BorrowDate"] != null)
            {
                dgvTransactions.Columns["BorrowDate"].HeaderText = "Borrow Date";
            }
            if (dgvTransactions.Columns["DueDate"] != null)
            {
                dgvTransactions.Columns["DueDate"].HeaderText = "Due Date";
            }
            if (dgvTransactions.Columns["Status"] != null)
            {
                dgvTransactions.Columns["Status"].HeaderText = "Status";
            }

            GridHelper.EnsureSrColumn(dgvTransactions, _currentPage, _pageSize);
            EnsureGridActionColumns(dgvTransactions);

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
                FilterTransactionsLocal();
            }
        }

        private void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                FilterTransactionsLocal();
            }
        }

        private void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                FilterTransactionsLocal();
            }
        }

        private void txtTxnMemberId_TextChanged(object? sender, EventArgs e)
        {
            _currentPage = 1; // Reset to page 1 on search key change
            FilterTransactionsLocal();
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

        private async void btnTxnRefresh_Click(object sender, EventArgs e)
        {
            await LoadTransactionsDataAsync();
        }

        private async void btnTxnBorrow_Click(object sender, EventArgs e)
        {
            using (var dialog = new FrmLoanDialog("Lend Book"))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.MemberId) || string.IsNullOrWhiteSpace(dialog.BookTitle))
                    {
                        MessageBox.Show("Please enter Member ID and Book Title.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string? copyId = await _txnService.GetCopyIdByBookTitleAsync(dialog.BookTitle);
                    if (string.IsNullOrWhiteSpace(copyId))
                    {
                        MessageBox.Show($"No copies available or book not found for title '{dialog.BookTitle}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var txn = new BorrowTransactionViewModel
                    {
                        TransactionId = $"TXN-2026-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}",
                        MemberId = dialog.MemberId,
                        CopyId = copyId,
                        BorrowDate = DateTime.Now,
                        DueDate = dialog.DueDate,
                        Status = dialog.Status,
                        FineAmount = 0.00m
                    };

                    bool success = await _txnService.CreateAsync(txn);
                    MessageBox.Show(success ? "Book borrowed successfully!" : "Failed to create borrow transaction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTransactionsDataAsync();
                }
            }
        }

        private async void dgvTransactions_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender!;
            if (dgv.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                var txn = (BorrowTransactionViewModel)dgv.Rows[e.RowIndex].DataBoundItem;
                var cellBounds = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var relativeX = dgv.PointToClient(Cursor.Position).X - cellBounds.Left;

                if (relativeX < cellBounds.Width / 2)
                {
                    // Edit / Return (✏️)
                    using (var dialog = new FrmLoanDialog("Edit Borrow Transaction", txn.MemberId, txn.BookTitle ?? "", txn.DueDate, txn.Status))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrWhiteSpace(dialog.MemberId) || string.IsNullOrWhiteSpace(dialog.BookTitle))
                            {
                                MessageBox.Show("Please enter Member ID and Book Title.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            var existing = await _txnService.GetByIdAsync(txn.TransactionId);
                            if (existing != null)
                            {
                                existing.MemberId = dialog.MemberId;
                                existing.DueDate = dialog.DueDate;

                                // If the book title has changed, resolve new copy ID
                                if (dialog.BookTitle != existing.BookTitle)
                                {
                                    string? copyId = await _txnService.GetCopyIdByBookTitleAsync(dialog.BookTitle);
                                    if (string.IsNullOrWhiteSpace(copyId))
                                    {
                                        MessageBox.Show($"No copies available or book not found for title '{dialog.BookTitle}'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    existing.CopyId = copyId;
                                    existing.BookTitle = dialog.BookTitle;
                                }

                                // Process Status Transitions
                                if (dialog.Status == "Returned")
                                {
                                    if (existing.Status != "Returned")
                                    {
                                        existing.ReturnDate = DateTime.Now;
                                        existing.Status = "Returned";
                                        if (existing.ReturnDate > existing.DueDate)
                                        {
                                            int overdueDays = (existing.ReturnDate.Value.Date - existing.DueDate.Date).Days;
                                            if (overdueDays > 0)
                                            {
                                                existing.FineAmount = overdueDays * 1.50m;
                                                MessageBox.Show($"Book returned overdue by {overdueDays} day(s). Fine calculated: ${existing.FineAmount}", "Overdue Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                existing.FineAmount = 0.00m;
                                            }
                                        }
                                        else
                                        {
                                            existing.FineAmount = 0.00m;
                                        }
                                    }
                                    else
                                     {
                                         // If already returned, recalculate fine in case Due Date changed
                                         if (existing.ReturnDate != null && existing.ReturnDate > existing.DueDate)
                                         {
                                             int overdueDays = (existing.ReturnDate.Value.Date - existing.DueDate.Date).Days;
                                             existing.FineAmount = overdueDays > 0 ? overdueDays * 1.50m : 0.00m;
                                         }
                                         else
                                         {
                                             existing.FineAmount = 0.00m;
                                         }
                                     }
                                }
                                else
                                {
                                    // Set back to Borrowed: clear return date and fine
                                    existing.ReturnDate = null;
                                    existing.FineAmount = 0.00m;
                                    existing.Status = "Borrowed";
                                }

                                bool success = await _txnService.UpdateAsync(existing);
                                MessageBox.Show(success ? "Transaction updated successfully!" : "Failed to update transaction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await LoadTransactionsDataAsync();
                            }
                        }
                    }
                }
                else
                {
                    // Delete (❌)
                    var confirm = MessageBox.Show($"Are you sure you want to soft delete transaction log '{txn.TransactionId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        bool success = await _txnService.DeleteAsync(txn.TransactionId);
                        MessageBox.Show(success ? "Transaction deleted successfully!" : "Failed to delete transaction.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTransactionsDataAsync();
                    }
                }
            }
        }
    }
}
