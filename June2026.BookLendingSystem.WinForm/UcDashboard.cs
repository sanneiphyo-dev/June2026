using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Microsoft.Data.SqlClient;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class UcDashboard : UserControl
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public UcDashboard()
        {
            InitializeComponent();
        }

        public async Task LoadDashboardDataAsync()
        {
            try
            {
                using IDbConnection db = new SqlConnection(sb.ConnectionString);

                // Fetch counts (only non-deleted)
                int booksCount = await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Books WHERE del_flg = 0");
                int membersCount = await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Members WHERE del_flg = 0");
                int activeBorrowsCount = await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Borrow_Transactions WHERE status = 'Borrowed' AND del_flg = 0");
                int pendingReservationsCount = await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Reservation WHERE status = 'Pending' AND del_flg = 0");

                // Update UI Labels
                lblBooksCount.Text = booksCount.ToString();
                lblMembersCount.Text = membersCount.ToString();
                lblActiveBorrowsCount.Text = activeBorrowsCount.ToString();
                lblReservationsCount.Text = pendingReservationsCount.ToString();

                // Fetch recent activities (only non-deleted)
                string query = @"
                    SELECT TOP 5 
                        m.[full_name] AS MemberName,
                        b.[title] AS BookTitle,
                        bt.[borrow_date] AS BorrowDate,
                        bt.[status] AS Status
                    FROM [dbo].[Borrow_Transactions] bt
                    INNER JOIN [dbo].[Members] m ON bt.[member_id] = m.[member_id]
                    INNER JOIN [dbo].[Book_Copies] bc ON bt.[copy_id] = bc.[copy_id]
                    INNER JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                    WHERE bt.[del_flg] = 0 AND m.[del_flg] = 0 AND bc.[del_flg] = 0 AND b.[del_flg] = 0
                    ORDER BY bt.[borrow_date] DESC";

                var recentActivities = (await db.QueryAsync<RecentActivityViewModel>(query)).ToList();

                dgvRecentActivity.DataSource = null;
                dgvRecentActivity.DataSource = recentActivities;

                if (dgvRecentActivity.Columns["MemberName"] != null)
                {
                    dgvRecentActivity.Columns["MemberName"].HeaderText = "Member Name";
                }
                if (dgvRecentActivity.Columns["BookTitle"] != null)
                {
                    dgvRecentActivity.Columns["BookTitle"].HeaderText = "Book Title";
                }
                if (dgvRecentActivity.Columns["BorrowDate"] != null)
                {
                    dgvRecentActivity.Columns["BorrowDate"].HeaderText = "Borrow Date";
                }
                if (dgvRecentActivity.Columns["Status"] != null)
                {
                    dgvRecentActivity.Columns["Status"].HeaderText = "Status";
                }

                GridHelper.EnsureSrColumn(dgvRecentActivity, 1, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dashboard data: {ex.Message}");
            }
        }

        public class RecentActivityViewModel
        {
            public string MemberName { get; set; } = string.Empty;
            public string BookTitle { get; set; } = string.Empty;
            public DateTime BorrowDate { get; set; }
            public string Status { get; set; } = string.Empty;
        }
    }
}
