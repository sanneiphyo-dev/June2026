using System;
using System.Windows.Forms;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmLoanDialog : Form
    {
        public string MemberId => txtMemberId.Text.Trim();
        public string BookTitle => txtBookTitle.Text.Trim();
        public DateTime DueDate => dtpDueDate.Value;
        public string Status => cboStatus.Text.Trim();

        public FrmLoanDialog(string headerText, string memberId = "", string bookTitle = "", DateTime? dueDate = null, string status = "Borrowed")
        {
            InitializeComponent();
            this.Text = headerText;
            this.lblHeader.Text = headerText;
            this.txtMemberId.Text = memberId;
            this.txtBookTitle.Text = bookTitle;
            this.dtpDueDate.Value = dueDate ?? DateTime.Now.AddDays(14);
            this.cboStatus.Text = status;
        }
    }
}
