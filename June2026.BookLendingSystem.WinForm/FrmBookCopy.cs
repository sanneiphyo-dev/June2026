using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.BookCopies;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmBookCopy : Form
    {
        private readonly BookCopyHttpClientService _copyService;

        public FrmBookCopy()
        {
            InitializeComponent();
            _copyService = new BookCopyHttpClientService();
        }

        private async void FrmBookCopy_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var copies = await _copyService.ReadAsync();
            dgvCopies.DataSource = null;
            dgvCopies.DataSource = copies;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCopyId.Text) || !int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please enter a valid Copy ID and numeric Book ID.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var copy = new BookCopyViewModel
            {
                CopyId = txtCopyId.Text.Trim(),
                BookId = bookId,
                BookCopyCount = string.IsNullOrWhiteSpace(txtCount.Text) ? "1" : txtCount.Text.Trim()
            };

            bool success = await _copyService.CreateAsync(copy);
            MessageBox.Show(success ? "Book copy added successfully via HttpClient!" : "Failed to add copy.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCopyId.Text) || !int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please select a Copy ID and valid Book ID to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var copy = new BookCopyViewModel
            {
                CopyId = txtCopyId.Text.Trim(),
                BookId = bookId,
                BookCopyCount = string.IsNullOrWhiteSpace(txtCount.Text) ? "1" : txtCount.Text.Trim()
            };

            bool success = await _copyService.UpdateAsync(copy);
            MessageBox.Show(success ? "Book copy updated successfully via HttpClient!" : "Failed to update copy.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string copyId = txtCopyId.Text.Trim();
            if (string.IsNullOrWhiteSpace(copyId))
            {
                MessageBox.Show("Please select a copy from the list to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete Copy ID '{copyId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool success = await _copyService.DeleteAsync(copyId);
                MessageBox.Show(success ? "Book copy deleted successfully via HttpClient!" : "Failed to delete copy.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtCopyId.Text = "";
            txtBookId.Text = "";
            txtCount.Text = "";
        }

        private void dgvCopies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCopies.Rows[e.RowIndex].DataBoundItem is BookCopyViewModel c)
            {
                txtCopyId.Text = c.CopyId;
                txtBookId.Text = c.BookId.ToString();
                txtCount.Text = c.BookCopyCount;
            }
        }
    }
}
