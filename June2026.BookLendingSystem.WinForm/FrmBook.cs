using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Books;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmBook : Form
    {
        private readonly BookHttpClientService _bookService;

        public FrmBook()
        {
            InitializeComponent();
            _bookService = new BookHttpClientService();
        }

        private async void FrmBook_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var books = await _bookService.ReadAsync();
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = books;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Please enter Title and Author.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new BookViewModel
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text.Trim(),
                Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text.Trim()
            };

            await _bookService.CreateAsync(book);
            MessageBox.Show("Book added successfully via HttpClient!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please select a book from the list to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new BookViewModel
            {
                BookId = bookId,
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text) ? null : txtPublisher.Text.Trim(),
                Category = string.IsNullOrWhiteSpace(txtCategory.Text) ? null : txtCategory.Text.Trim()
            };

            await _bookService.UpdateAsync(book);
            MessageBox.Show("Book updated successfully via HttpClient!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please select a book from the list to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete Book ID #{bookId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                await _bookService.DeleteAsync(bookId);
                MessageBox.Show("Book deleted successfully via HttpClient!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtBookId.Text = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPublisher.Text = "";
            txtCategory.Text = "";
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooks.Rows[e.RowIndex].DataBoundItem is BookViewModel b)
            {
                txtBookId.Text = b.BookId.ToString();
                txtTitle.Text = b.Title;
                txtAuthor.Text = b.Author;
                txtPublisher.Text = b.Publisher ?? "";
                txtCategory.Text = b.Category ?? "";
            }
        }
    }
}
