using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Books;
using June2026.BookLendingSystem.ConsoleApp.Features.Members;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class Form1 : Form
    {
        private readonly BookHttpClientService _bookService;
        private readonly MemberHttpClientService _memberService;

        public Form1()
        {
            InitializeComponent();
            _bookService = new BookHttpClientService();
            _memberService = new MemberHttpClientService();
        }

        #region Books Management Event Handlers
        private async void btnBookLoad_Click(object sender, EventArgs e)
        {
            await LoadBooksAsync();
        }

        private async Task LoadBooksAsync()
        {
            var books = await _bookService.ReadAsync();
            dgvBooks.DataSource = books;
        }

        private async void btnBookAdd_Click(object sender, EventArgs e)
        {
            var book = new BookViewModel
            {
                Title = txtBookTitle.Text.Trim(),
                Author = txtBookAuthor.Text.Trim(),
                Publisher = string.IsNullOrWhiteSpace(txtBookPublisher.Text) ? null : txtBookPublisher.Text.Trim(),
                Category = string.IsNullOrWhiteSpace(txtBookCategory.Text) ? null : txtBookCategory.Text.Trim()
            };

            await _bookService.CreateAsync(book);
            MessageBox.Show("Sent Add Book HTTP Request.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadBooksAsync();
        }

        private async void btnBookUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please enter a valid numeric Book ID to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new BookViewModel
            {
                BookId = bookId,
                Title = txtBookTitle.Text.Trim(),
                Author = txtBookAuthor.Text.Trim(),
                Publisher = string.IsNullOrWhiteSpace(txtBookPublisher.Text) ? null : txtBookPublisher.Text.Trim(),
                Category = string.IsNullOrWhiteSpace(txtBookCategory.Text) ? null : txtBookCategory.Text.Trim()
            };

            await _bookService.UpdateAsync(book);
            MessageBox.Show("Sent Update Book HTTP Request.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadBooksAsync();
        }

        private async void btnBookDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please enter a valid numeric Book ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await _bookService.DeleteAsync(bookId);
            MessageBox.Show("Sent Delete Book HTTP Request.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadBooksAsync();
        }
        #endregion

        #region Members Management Event Handlers
        private async void btnMemberLoad_Click(object sender, EventArgs e)
        {
            await LoadMembersAsync();
        }

        private async Task LoadMembersAsync()
        {
            var members = await _memberService.ReadAsync();
            dgvMembers.DataSource = members;
        }

        private async void btnMemberAdd_Click(object sender, EventArgs e)
        {
            var member = new MemberViewModel
            {
                MemberId = txtMemberId.Text.Trim(),
                FullName = txtMemberName.Text.Trim(),
                Email = txtMemberEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtMemberPhone.Text) ? null : txtMemberPhone.Text.Trim(),
                Role = string.IsNullOrWhiteSpace(txtMemberRole.Text) ? "Student" : txtMemberRole.Text.Trim(),
                Status = string.IsNullOrWhiteSpace(txtMemberStatus.Text) ? "Active" : txtMemberStatus.Text.Trim()
            };

            bool success = await _memberService.CreateAsync(member);
            MessageBox.Show(success ? "Member added successfully via HttpClient!" : "Failed to add member.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadMembersAsync();
        }

        private async void btnMemberUpdate_Click(object sender, EventArgs e)
        {
            var member = new MemberViewModel
            {
                MemberId = txtMemberId.Text.Trim(),
                FullName = txtMemberName.Text.Trim(),
                Email = txtMemberEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtMemberPhone.Text) ? null : txtMemberPhone.Text.Trim(),
                Role = string.IsNullOrWhiteSpace(txtMemberRole.Text) ? "Student" : txtMemberRole.Text.Trim(),
                Status = string.IsNullOrWhiteSpace(txtMemberStatus.Text) ? "Active" : txtMemberStatus.Text.Trim()
            };

            bool success = await _memberService.UpdateAsync(member);
            MessageBox.Show(success ? "Member updated successfully via HttpClient!" : "Failed to update member.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadMembersAsync();
        }

        private async void btnMemberDelete_Click(object sender, EventArgs e)
        {
            string memberId = txtMemberId.Text.Trim();
            if (string.IsNullOrWhiteSpace(memberId))
            {
                MessageBox.Show("Please enter a Member ID to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = await _memberService.DeleteAsync(memberId);
            MessageBox.Show(success ? "Member deleted successfully via HttpClient!" : "Failed to delete member.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadMembersAsync();
        }
        #endregion
    }
}
