using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Members;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmMember : Form
    {
        private readonly MemberHttpClientService _memberService;

        public FrmMember()
        {
            InitializeComponent();
            _memberService = new MemberHttpClientService();
        }

        private async void FrmMember_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var members = await _memberService.ReadAsync();
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = members;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMemberId.Text) || string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter Member ID, Full Name, and Email.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var member = new MemberViewModel
            {
                MemberId = txtMemberId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                Role = string.IsNullOrWhiteSpace(txtRole.Text) ? "Student" : txtRole.Text.Trim(),
                Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Active" : txtStatus.Text.Trim()
            };

            bool success = await _memberService.CreateAsync(member);
            MessageBox.Show(success ? "Member created successfully via HttpClient!" : "Failed to create member.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string memberId = txtMemberId.Text.Trim();
            if (string.IsNullOrWhiteSpace(memberId))
            {
                MessageBox.Show("Please select a member to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var member = new MemberViewModel
            {
                MemberId = memberId,
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text.Trim(),
                Role = string.IsNullOrWhiteSpace(txtRole.Text) ? "Student" : txtRole.Text.Trim(),
                Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Active" : txtStatus.Text.Trim()
            };

            bool success = await _memberService.UpdateAsync(member);
            MessageBox.Show(success ? "Member updated successfully via HttpClient!" : "Failed to update member.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string memberId = txtMemberId.Text.Trim();
            if (string.IsNullOrWhiteSpace(memberId))
            {
                MessageBox.Show("Please select a member from the list to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete Member ID '{memberId}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool success = await _memberService.DeleteAsync(memberId);
                MessageBox.Show(success ? "Member deleted successfully via HttpClient!" : "Failed to delete member.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtMemberId.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtRole.Text = "";
            txtStatus.Text = "";
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMembers.Rows[e.RowIndex].DataBoundItem is MemberViewModel m)
            {
                txtMemberId.Text = m.MemberId;
                txtFullName.Text = m.FullName;
                txtEmail.Text = m.Email;
                txtPhone.Text = m.Phone ?? "";
                txtRole.Text = m.Role;
                txtStatus.Text = m.Status;
            }
        }
    }
}
