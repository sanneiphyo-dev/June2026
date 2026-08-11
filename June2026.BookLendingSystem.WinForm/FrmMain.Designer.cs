namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        // Core Sidebar & Main Shell Controls
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnOpenDashboard;
        private System.Windows.Forms.Button btnOpenBooks;
        private System.Windows.Forms.Button btnOpenCopies;
        private System.Windows.Forms.Button btnOpenMembers;
        private System.Windows.Forms.Button btnOpenTransactions;
        private System.Windows.Forms.Button btnOpenReservations;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlContent;

        // Modular view controls
        private UcDashboard ucDashboard;
        private UcBook ucBook;
        private UcCopy ucCopy;
        private UcMember ucMember;
        private UcLoan ucLoan;
        private UcReservation ucReservation;

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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnOpenDashboard = new System.Windows.Forms.Button();
            this.btnOpenBooks = new System.Windows.Forms.Button();
            this.btnOpenCopies = new System.Windows.Forms.Button();
            this.btnOpenMembers = new System.Windows.Forms.Button();
            this.btnOpenTransactions = new System.Windows.Forms.Button();
            this.btnOpenReservations = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();

            // Instantiate UserControls
            this.ucDashboard = new June2026.BookLendingSystem.WinForm.UcDashboard();
            this.ucBook = new June2026.BookLendingSystem.WinForm.UcBook();
            this.ucCopy = new June2026.BookLendingSystem.WinForm.UcCopy();
            this.ucMember = new June2026.BookLendingSystem.WinForm.UcMember();
            this.ucLoan = new June2026.BookLendingSystem.WinForm.UcLoan();
            this.ucReservation = new June2026.BookLendingSystem.WinForm.UcReservation();

            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Controls.Add(this.btnOpenDashboard);
            this.pnlSidebar.Controls.Add(this.btnOpenBooks);
            this.pnlSidebar.Controls.Add(this.btnOpenCopies);
            this.pnlSidebar.Controls.Add(this.btnOpenMembers);
            this.pnlSidebar.Controls.Add(this.btnOpenTransactions);
            this.pnlSidebar.Controls.Add(this.btnOpenReservations);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 600);

            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(15, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(190, 40);
            this.lblLogo.Text = "📚 Library Manager";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // btnOpenDashboard
            // 
            this.btnOpenDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnOpenDashboard.FlatAppearance.BorderSize = 0;
            this.btnOpenDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenDashboard.ForeColor = System.Drawing.Color.White;
            this.btnOpenDashboard.Location = new System.Drawing.Point(15, 95);
            this.btnOpenDashboard.Name = "btnOpenDashboard";
            this.btnOpenDashboard.Size = new System.Drawing.Size(190, 45);
            this.btnOpenDashboard.Text = "🏠  Dashboard";
            this.btnOpenDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenDashboard.Click += new System.EventHandler(this.btnOpenDashboard_Click);

            // 
            // btnOpenBooks
            // 
            this.btnOpenBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnOpenBooks.FlatAppearance.BorderSize = 0;
            this.btnOpenBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenBooks.ForeColor = System.Drawing.Color.White;
            this.btnOpenBooks.Location = new System.Drawing.Point(15, 150);
            this.btnOpenBooks.Name = "btnOpenBooks";
            this.btnOpenBooks.Size = new System.Drawing.Size(190, 45);
            this.btnOpenBooks.Text = "📚  Books";
            this.btnOpenBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenBooks.Click += new System.EventHandler(this.btnOpenBooks_Click);

            // 
            // btnOpenCopies
            // 
            this.btnOpenCopies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnOpenCopies.FlatAppearance.BorderSize = 0;
            this.btnOpenCopies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCopies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenCopies.ForeColor = System.Drawing.Color.White;
            this.btnOpenCopies.Location = new System.Drawing.Point(15, 205);
            this.btnOpenCopies.Name = "btnOpenCopies";
            this.btnOpenCopies.Size = new System.Drawing.Size(190, 45);
            this.btnOpenCopies.Text = "📖  Book Copies";
            this.btnOpenCopies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenCopies.Click += new System.EventHandler(this.btnOpenCopies_Click);

            // 
            // btnOpenMembers
            // 
            this.btnOpenMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnOpenMembers.FlatAppearance.BorderSize = 0;
            this.btnOpenMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMembers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenMembers.ForeColor = System.Drawing.Color.White;
            this.btnOpenMembers.Location = new System.Drawing.Point(15, 260);
            this.btnOpenMembers.Name = "btnOpenMembers";
            this.btnOpenMembers.Size = new System.Drawing.Size(190, 45);
            this.btnOpenMembers.Text = "👥  Members";
            this.btnOpenMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenMembers.Click += new System.EventHandler(this.btnOpenMembers_Click);

            // 
            // btnOpenTransactions
            // 
            this.btnOpenTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnOpenTransactions.FlatAppearance.BorderSize = 0;
            this.btnOpenTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTransactions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenTransactions.ForeColor = System.Drawing.Color.White;
            this.btnOpenTransactions.Location = new System.Drawing.Point(15, 315);
            this.btnOpenTransactions.Name = "btnOpenTransactions";
            this.btnOpenTransactions.Size = new System.Drawing.Size(190, 45);
            this.btnOpenTransactions.Text = "💳  Borrow/Return";
            this.btnOpenTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenTransactions.Click += new System.EventHandler(this.btnOpenTransactions_Click);

            // 
            // btnOpenReservations
            // 
            this.btnOpenReservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnOpenReservations.FlatAppearance.BorderSize = 0;
            this.btnOpenReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenReservations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenReservations.ForeColor = System.Drawing.Color.White;
            this.btnOpenReservations.Location = new System.Drawing.Point(15, 370);
            this.btnOpenReservations.Name = "btnOpenReservations";
            this.btnOpenReservations.Size = new System.Drawing.Size(190, 45);
            this.btnOpenReservations.Text = "📌  Reservations";
            this.btnOpenReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenReservations.Click += new System.EventHandler(this.btnOpenReservations_Click);

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(220, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(804, 80);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 32);
            this.lblTitle.Text = "System Dashboard";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(27, 47);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(295, 17);
            this.lblSubtitle.Text = "Real-time system overview. Metrics update automatically.";

            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlContent.Controls.Add(this.ucDashboard);
            this.pnlContent.Controls.Add(this.ucBook);
            this.pnlContent.Controls.Add(this.ucCopy);
            this.pnlContent.Controls.Add(this.ucMember);
            this.pnlContent.Controls.Add(this.ucLoan);
            this.pnlContent.Controls.Add(this.ucReservation);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(804, 520);

            // Dock modular UserControls
            this.ucDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReservation.Dock = System.Windows.Forms.DockStyle.Fill;

            // 
            // FrmMain
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Lending System - Executive Control Center";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
