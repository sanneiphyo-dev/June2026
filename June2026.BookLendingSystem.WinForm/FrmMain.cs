using System;
using System.Threading.Tasks;
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

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await ShowViewAsync(ucDashboard, "System Dashboard", "Real-time system overview. Metrics update automatically.");
        }

        private async Task ShowViewAsync(UserControl activeControl, string title, string subtitle)
        {
            // Toggle visibility
            ucDashboard.Visible = false;
            ucBook.Visible = false;
            ucCopy.Visible = false;
            ucMember.Visible = false;
            ucLoan.Visible = false;
            ucReservation.Visible = false;

            activeControl.Visible = true;
            lblTitle.Text = title;
            lblSubtitle.Text = subtitle;

            // Trigger specific loads
            if (activeControl == ucDashboard)
            {
                await ucDashboard.LoadDashboardDataAsync();
            }
            else if (activeControl == ucBook)
            {
                await ucBook.LoadBooksDataAsync();
            }
            else if (activeControl == ucCopy)
            {
                await ucCopy.LoadCopiesDataAsync();
            }
            else if (activeControl == ucMember)
            {
                await ucMember.LoadMembersDataAsync();
            }
            else if (activeControl == ucLoan)
            {
                await ucLoan.LoadTransactionsDataAsync();
            }
            else if (activeControl == ucReservation)
            {
                await ucReservation.LoadReservationsDataAsync();
            }
        }

        private async void btnOpenDashboard_Click(object sender, EventArgs e)
        {
            await ShowViewAsync(ucDashboard, "System Dashboard", "Real-time system overview. Metrics update automatically.");
        }

        private async void btnOpenBooks_Click(object sender, EventArgs e)
        {
            await ShowViewAsync(ucBook, "Book Catalog", "Register new titles to the central catalog.");
        }

        private async void btnOpenCopies_Click(object sender, EventArgs e)
        {
            await ShowViewAsync(ucCopy, "Book Inventory Copies", "Manage physical inventory stock counts per title.");
        }

        private async void btnOpenMembers_Click(object sender, EventArgs e)
        {
            await ShowViewAsync(ucMember, "Member Registry", "Manage library patrons and administrative staff profiles.");
        }

        private async void btnOpenTransactions_Click(object sender, EventArgs e)
        {
            await ShowViewAsync(ucLoan, "Borrowing / Return Transactions", "Filter active loans and log history using search.");
        }

        private async void btnOpenReservations_Click(object sender, EventArgs e)
        {
            await ShowViewAsync(ucReservation, "Reservations Queue", "Manage hold queue and reservation approvals.");
        }
    }
}
