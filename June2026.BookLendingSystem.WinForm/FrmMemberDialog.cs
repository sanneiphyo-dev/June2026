using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmMemberDialog : Form
    {
        public string MemberId => txtMemberId.Text.Trim();
        public string FullName => txtFullName.Text.Trim();
        public string Email => txtEmail.Text.Trim();
        public string Phone => txtPhone.Text.Trim();
        public string Role => txtRole.Text.Trim();
        public string Status => cboStatus.Text.Trim();

        public FrmMemberDialog(string headerText, string memberId = "", string fullName = "", string email = "", string phone = "", string role = "", string status = "Active")
        {
            InitializeComponent();
            this.Text = headerText;
            this.lblHeader.Text = headerText;
            this.txtMemberId.Text = memberId;
            this.txtFullName.Text = fullName;
            this.txtEmail.Text = email;
            this.txtPhone.Text = phone;
            this.txtRole.Text = role;
            this.cboStatus.Text = status;

            // Make MemberId read-only when editing an existing member
            if (!string.IsNullOrWhiteSpace(memberId) && headerText.Contains("Edit"))
            {
                txtMemberId.ReadOnly = true;
            }
        }
    }
}
