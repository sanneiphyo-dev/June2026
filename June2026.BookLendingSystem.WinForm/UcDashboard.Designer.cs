namespace June2026.BookLendingSystem.WinForm
{
    partial class UcDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCardBooks;
        private System.Windows.Forms.Label lblBooksTitle;
        private System.Windows.Forms.Label lblBooksCount;
        private System.Windows.Forms.Label lblBooksIcon;
        private System.Windows.Forms.Panel pnlCardMembers;
        private System.Windows.Forms.Label lblMembersTitle;
        private System.Windows.Forms.Label lblMembersCount;
        private System.Windows.Forms.Label lblMembersIcon;
        private System.Windows.Forms.Panel pnlCardActiveBorrows;
        private System.Windows.Forms.Label lblActiveBorrowsTitle;
        private System.Windows.Forms.Label lblActiveBorrowsCount;
        private System.Windows.Forms.Label lblActiveBorrowsIcon;
        private System.Windows.Forms.Panel pnlCardReservations;
        private System.Windows.Forms.Label lblReservationsTitle;
        private System.Windows.Forms.Label lblReservationsCount;
        private System.Windows.Forms.Label lblReservationsIcon;
        private System.Windows.Forms.Label lblRecentActivityTitle;
        private System.Windows.Forms.DataGridView dgvRecentActivity;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlCardBooks = new System.Windows.Forms.Panel();
            this.lblBooksTitle = new System.Windows.Forms.Label();
            this.lblBooksCount = new System.Windows.Forms.Label();
            this.lblBooksIcon = new System.Windows.Forms.Label();
            this.pnlCardMembers = new System.Windows.Forms.Panel();
            this.lblMembersTitle = new System.Windows.Forms.Label();
            this.lblMembersCount = new System.Windows.Forms.Label();
            this.lblMembersIcon = new System.Windows.Forms.Label();
            this.pnlCardActiveBorrows = new System.Windows.Forms.Panel();
            this.lblActiveBorrowsTitle = new System.Windows.Forms.Label();
            this.lblActiveBorrowsCount = new System.Windows.Forms.Label();
            this.lblActiveBorrowsIcon = new System.Windows.Forms.Label();
            this.pnlCardReservations = new System.Windows.Forms.Panel();
            this.lblReservationsTitle = new System.Windows.Forms.Label();
            this.lblReservationsCount = new System.Windows.Forms.Label();
            this.lblReservationsIcon = new System.Windows.Forms.Label();
            this.lblRecentActivityTitle = new System.Windows.Forms.Label();
            this.dgvRecentActivity = new System.Windows.Forms.DataGridView();
            this.pnlCardBooks.SuspendLayout();
            this.pnlCardMembers.SuspendLayout();
            this.pnlCardActiveBorrows.SuspendLayout();
            this.pnlCardReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlCardBooks
            // 
            this.pnlCardBooks.BackColor = System.Drawing.Color.White;
            this.pnlCardBooks.Controls.Add(this.lblBooksTitle);
            this.pnlCardBooks.Controls.Add(this.lblBooksCount);
            this.pnlCardBooks.Controls.Add(this.lblBooksIcon);
            this.pnlCardBooks.Location = new System.Drawing.Point(25, 20);
            this.pnlCardBooks.Name = "pnlCardBooks";
            this.pnlCardBooks.Size = new System.Drawing.Size(175, 110);

            // 
            // lblBooksTitle
            // 
            this.lblBooksTitle.AutoSize = true;
            this.lblBooksTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBooksTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBooksTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBooksTitle.Name = "lblBooksTitle";
            this.lblBooksTitle.Size = new System.Drawing.Size(71, 15);
            this.lblBooksTitle.Text = "Total Books";

            // 
            // lblBooksCount
            // 
            this.lblBooksCount.AutoSize = true;
            this.lblBooksCount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBooksCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblBooksCount.Location = new System.Drawing.Point(12, 45);
            this.lblBooksCount.Name = "lblBooksCount";
            this.lblBooksCount.Size = new System.Drawing.Size(34, 41);
            this.lblBooksCount.Text = "0";

            // 
            // lblBooksIcon
            // 
            this.lblBooksIcon.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblBooksIcon.Location = new System.Drawing.Point(125, 20);
            this.lblBooksIcon.Name = "lblBooksIcon";
            this.lblBooksIcon.Size = new System.Drawing.Size(40, 40);
            this.lblBooksIcon.Text = "📚";
            this.lblBooksIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlCardMembers
            // 
            this.pnlCardMembers.BackColor = System.Drawing.Color.White;
            this.pnlCardMembers.Controls.Add(this.lblMembersTitle);
            this.pnlCardMembers.Controls.Add(this.lblMembersCount);
            this.pnlCardMembers.Controls.Add(this.lblMembersIcon);
            this.pnlCardMembers.Location = new System.Drawing.Point(215, 20);
            this.pnlCardMembers.Name = "pnlCardMembers";
            this.pnlCardMembers.Size = new System.Drawing.Size(175, 110);

            // 
            // lblMembersTitle
            // 
            this.lblMembersTitle.AutoSize = true;
            this.lblMembersTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMembersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMembersTitle.Location = new System.Drawing.Point(15, 15);
            this.lblMembersTitle.Name = "lblMembersTitle";
            this.lblMembersTitle.Size = new System.Drawing.Size(91, 15);
            this.lblMembersTitle.Text = "Total Members";

            // 
            // lblMembersCount
            // 
            this.lblMembersCount.AutoSize = true;
            this.lblMembersCount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblMembersCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblMembersCount.Location = new System.Drawing.Point(12, 45);
            this.lblMembersCount.Name = "lblMembersCount";
            this.lblMembersCount.Size = new System.Drawing.Size(34, 41);
            this.lblMembersCount.Text = "0";

            // 
            // lblMembersIcon
            // 
            this.lblMembersIcon.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblMembersIcon.Location = new System.Drawing.Point(125, 20);
            this.lblMembersIcon.Name = "lblMembersIcon";
            this.lblMembersIcon.Size = new System.Drawing.Size(40, 40);
            this.lblMembersIcon.Text = "👥";
            this.lblMembersIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlCardActiveBorrows
            // 
            this.pnlCardActiveBorrows.BackColor = System.Drawing.Color.White;
            this.pnlCardActiveBorrows.Controls.Add(this.lblActiveBorrowsTitle);
            this.pnlCardActiveBorrows.Controls.Add(this.lblActiveBorrowsCount);
            this.pnlCardActiveBorrows.Controls.Add(this.lblActiveBorrowsIcon);
            this.pnlCardActiveBorrows.Location = new System.Drawing.Point(405, 20);
            this.pnlCardActiveBorrows.Name = "pnlCardActiveBorrows";
            this.pnlCardActiveBorrows.Size = new System.Drawing.Size(175, 110);

            // 
            // lblActiveBorrowsTitle
            // 
            this.lblActiveBorrowsTitle.AutoSize = true;
            this.lblActiveBorrowsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiveBorrowsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblActiveBorrowsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblActiveBorrowsTitle.Name = "lblActiveBorrowsTitle";
            this.lblActiveBorrowsTitle.Size = new System.Drawing.Size(91, 15);
            this.lblActiveBorrowsTitle.Text = "Active Borrows";

            // 
            // lblActiveBorrowsCount
            // 
            this.lblActiveBorrowsCount.AutoSize = true;
            this.lblActiveBorrowsCount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblActiveBorrowsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.lblActiveBorrowsCount.Location = new System.Drawing.Point(12, 45);
            this.lblActiveBorrowsCount.Name = "lblActiveBorrowsCount";
            this.lblActiveBorrowsCount.Size = new System.Drawing.Size(34, 41);
            this.lblActiveBorrowsCount.Text = "0";

            // 
            // lblActiveBorrowsIcon
            // 
            this.lblActiveBorrowsIcon.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblActiveBorrowsIcon.Location = new System.Drawing.Point(125, 20);
            this.lblActiveBorrowsIcon.Name = "lblActiveBorrowsIcon";
            this.lblActiveBorrowsIcon.Size = new System.Drawing.Size(40, 40);
            this.lblActiveBorrowsIcon.Text = "💳";
            this.lblActiveBorrowsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlCardReservations
            // 
            this.pnlCardReservations.BackColor = System.Drawing.Color.White;
            this.pnlCardReservations.Controls.Add(this.lblReservationsTitle);
            this.pnlCardReservations.Controls.Add(this.lblReservationsCount);
            this.pnlCardReservations.Controls.Add(this.lblReservationsIcon);
            this.pnlCardReservations.Location = new System.Drawing.Point(595, 20);
            this.pnlCardReservations.Name = "pnlCardReservations";
            this.pnlCardReservations.Size = new System.Drawing.Size(175, 110);

            // 
            // lblReservationsTitle
            // 
            this.lblReservationsTitle.AutoSize = true;
            this.lblReservationsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReservationsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblReservationsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblReservationsTitle.Name = "lblReservationsTitle";
            this.lblReservationsTitle.Size = new System.Drawing.Size(77, 15);
            this.lblReservationsTitle.Text = "Reservations";

            // 
            // lblReservationsCount
            // 
            this.lblReservationsCount.AutoSize = true;
            this.lblReservationsCount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblReservationsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(63)))), ((int)(((byte)(94)))));
            this.lblReservationsCount.Location = new System.Drawing.Point(12, 45);
            this.lblReservationsCount.Name = "lblReservationsCount";
            this.lblReservationsCount.Size = new System.Drawing.Size(34, 41);
            this.lblReservationsCount.Text = "0";

            // 
            // lblReservationsIcon
            // 
            this.lblReservationsIcon.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblReservationsIcon.Location = new System.Drawing.Point(125, 20);
            this.lblReservationsIcon.Name = "lblReservationsIcon";
            this.lblReservationsIcon.Size = new System.Drawing.Size(40, 40);
            this.lblReservationsIcon.Text = "📌";
            this.lblReservationsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblRecentActivityTitle
            // 
            this.lblRecentActivityTitle.AutoSize = true;
            this.lblRecentActivityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentActivityTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRecentActivityTitle.Location = new System.Drawing.Point(25, 160);
            this.lblRecentActivityTitle.Name = "lblRecentActivityTitle";
            this.lblRecentActivityTitle.Size = new System.Drawing.Size(205, 21);
            this.lblRecentActivityTitle.Text = "Recent Borrowing Activity";

            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.AllowUserToAddRows = false;
            this.dgvRecentActivity.AllowUserToDeleteRows = false;
            this.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentActivity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentActivity.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentActivity.EnableHeadersVisualStyles = false;
            this.dgvRecentActivity.Location = new System.Drawing.Point(25, 195);
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.ReadOnly = true;
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentActivity.Size = new System.Drawing.Size(745, 290);
            this.dgvRecentActivity.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvRecentActivity.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvRecentActivity.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvRecentActivity.ColumnHeadersHeight = 35;
            this.dgvRecentActivity.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvRecentActivity.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.dgvRecentActivity.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // 
            // UcDashboard
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.pnlCardBooks);
            this.Controls.Add(this.pnlCardMembers);
            this.Controls.Add(this.pnlCardActiveBorrows);
            this.Controls.Add(this.pnlCardReservations);
            this.Controls.Add(this.lblRecentActivityTitle);
            this.Controls.Add(this.dgvRecentActivity);
            this.Name = "UcDashboard";
            this.Size = new System.Drawing.Size(804, 520);
            this.pnlCardBooks.ResumeLayout(false);
            this.pnlCardBooks.PerformLayout();
            this.pnlCardMembers.ResumeLayout(false);
            this.pnlCardMembers.PerformLayout();
            this.pnlCardActiveBorrows.ResumeLayout(false);
            this.pnlCardActiveBorrows.PerformLayout();
            this.pnlCardReservations.ResumeLayout(false);
            this.pnlCardReservations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
