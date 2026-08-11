using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmBookDialog : Form
    {
        public string BookTitle => txtTitle.Text.Trim();
        public string Author => txtAuthor.Text.Trim();
        public string Publisher => txtPublisher.Text.Trim();
        public string Category => txtCategory.Text.Trim();

        public FrmBookDialog(string headerText, string title = "", string author = "", string publisher = "", string category = "")
        {
            InitializeComponent();
            this.Text = headerText;
            this.lblHeader.Text = headerText;
            this.txtTitle.Text = title;
            this.txtAuthor.Text = author;
            this.txtPublisher.Text = publisher;
            this.txtCategory.Text = category;
        }
    }
}
