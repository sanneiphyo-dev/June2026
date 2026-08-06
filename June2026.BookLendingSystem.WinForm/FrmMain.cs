using System;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Shared;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            DatabaseInitializer.InitDatabaseSchema();
        }

        private void btnOpenBooks_Click(object sender, EventArgs e)
        {
            var frm = new FrmBook();
            frm.ShowDialog();
        }

        private void btnOpenCopies_Click(object sender, EventArgs e)
        {
            var frm = new FrmBookCopy();
            frm.ShowDialog();
        }

        private void btnOpenMembers_Click(object sender, EventArgs e)
        {
            var frm = new FrmMember();
            frm.ShowDialog();
        }

        private void btnOpenTransactions_Click(object sender, EventArgs e)
        {
            var frm = new FrmBorrowTransaction();
            frm.ShowDialog();
        }

        private void btnOpenReservations_Click(object sender, EventArgs e)
        {
            var frm = new FrmReservation();
            frm.ShowDialog();
        }
    }
}
