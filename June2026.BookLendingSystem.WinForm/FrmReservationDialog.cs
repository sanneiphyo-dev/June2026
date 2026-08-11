using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmReservationDialog : Form
    {
        public string BookId => txtBookId.Text.Trim();
        public string BookTitle => lblBookLabel.Text.Trim();

        public string MemberId => txtMemberId.Text.Trim();
        public string Status => cboStatus.Text.Trim();

        public FrmReservationDialog(string headerText, string bookId = "", string memberId = "", string status = "")
        {
            InitializeComponent();
            this.Text = headerText;
            this.lblHeader.Text = headerText;
            this.lblBookLabel.Text = BookTitle;
            this.txtMemberId.Text = memberId;
            this.cboStatus.Text = status;
        }

        private void lblBookLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
