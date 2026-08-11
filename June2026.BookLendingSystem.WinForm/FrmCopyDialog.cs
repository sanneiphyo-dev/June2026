using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmCopyDialog : Form
    {
        public string BookTitle => txtBookTitle.Text.Trim();
        public string CopyCount => txtCopyCount.Text.Trim();

        public FrmCopyDialog(string headerText, string bookTitle = "", string copyCount = "")
        {
            InitializeComponent();
            this.Text = headerText;
            this.lblHeader.Text = headerText;
            this.txtBookTitle.Text = bookTitle;
            this.txtCopyCount.Text = copyCount;
        }

        private void lblCopyCountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
