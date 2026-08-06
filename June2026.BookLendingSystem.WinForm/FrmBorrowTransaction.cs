using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmBorrowTransaction : Form
    {
        private readonly BorrowTransactionHttpClientService _txnService;

        public FrmBorrowTransaction()
        {
            InitializeComponent();
            _txnService = new BorrowTransactionHttpClientService();
        }

        private async void FrmBorrowTransaction_Load(object sender, EventArgs e)
        {
            dtpDueDate.Value = DateTime.Now.AddDays(14);
            await LoadDataAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var txns = await _txnService.ReadAsync();
            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = txns;
        }

        private async void btnBorrow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTxnId.Text) || string.IsNullOrWhiteSpace(txtMemberId.Text) || string.IsNullOrWhiteSpace(txtCopyId.Text))
            {
                MessageBox.Show("Please enter Transaction ID, Member ID, and Copy ID.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var txn = new BorrowTransactionViewModel
            {
                TransactionId = txtTxnId.Text.Trim(),
                MemberId = txtMemberId.Text.Trim(),
                CopyId = txtCopyId.Text.Trim(),
                BorrowDate = DateTime.Now,
                DueDate = dtpDueDate.Value,
                Status = "Borrowed",
                FineAmount = 0.00m
            };

            bool success = await _txnService.CreateAsync(txn);
            MessageBox.Show(success ? "Book borrowed successfully via HttpClient!" : "Failed to create borrow transaction.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnReturn_Click(object sender, EventArgs e)
        {
            string txnId = txtTxnId.Text.Trim();
            if (string.IsNullOrWhiteSpace(txnId))
            {
                MessageBox.Show("Please select a transaction to mark as returned.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existing = await _txnService.GetByIdAsync(txnId);
            if (existing != null)
            {
                existing.ReturnDate = DateTime.Now;
                existing.Status = "Returned";
                if (DateTime.Now > existing.DueDate)
                {
                    int overdueDays = (DateTime.Now - existing.DueDate).Days;
                    existing.FineAmount = overdueDays * 1.50m;
                    MessageBox.Show($"Book returned overdue by {overdueDays} day(s). Fine calculated: ${existing.FineAmount}", "Overdue Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                bool success = await _txnService.UpdateAsync(existing);
                MessageBox.Show(success ? "Book returned successfully via HttpClient!" : "Failed to update return transaction.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await LoadDataAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string txnId = txtTxnId.Text.Trim();
            if (string.IsNullOrWhiteSpace(txnId))
            {
                MessageBox.Show("Please select a transaction from the list to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete Transaction ID '{txnId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool success = await _txnService.DeleteAsync(txnId);
                MessageBox.Show(success ? "Transaction deleted successfully via HttpClient!" : "Failed to delete transaction.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await LoadDataAsync();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtTxnId.Text = "";
            txtMemberId.Text = "";
            txtCopyId.Text = "";
            txtFineAmount.Text = "0.00";
            txtStatus.Text = "Borrowed";
            dtpDueDate.Value = DateTime.Now.AddDays(14);
        }

        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTransactions.Rows[e.RowIndex].DataBoundItem is BorrowTransactionViewModel t)
            {
                txtTxnId.Text = t.TransactionId;
                txtMemberId.Text = t.MemberId;
                txtCopyId.Text = t.CopyId;
                txtFineAmount.Text = t.FineAmount.ToString("0.00");
                txtStatus.Text = t.Status;
                if (t.DueDate > DateTime.MinValue) dtpDueDate.Value = t.DueDate;
            }
        }
    }
}
