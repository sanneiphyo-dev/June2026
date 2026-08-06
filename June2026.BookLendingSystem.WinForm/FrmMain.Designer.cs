namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Button btnOpenBooks;
        private System.Windows.Forms.Button btnOpenCopies;
        private System.Windows.Forms.Button btnOpenMembers;
        private System.Windows.Forms.Button btnOpenTransactions;
        private System.Windows.Forms.Button btnOpenReservations;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.btnOpenBooks = new System.Windows.Forms.Button();
            this.btnOpenCopies = new System.Windows.Forms.Button();
            this.btnOpenMembers = new System.Windows.Forms.Button();
            this.btnOpenTransactions = new System.Windows.Forms.Button();
            this.btnOpenReservations = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader (Deep Royal Blue)
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 90);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Text = "BOOK LENDING SYSTEM";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblSubtitle.Location = new System.Drawing.Point(32, 55);
            this.lblSubtitle.Text = "Blue & White Windows Forms Dashboard (HttpClient Architecture)";

            // 
            // Navigation Buttons (Royal Blue with White Text)
            // 
            this.btnOpenBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnOpenBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenBooks.ForeColor = System.Drawing.Color.White;
            this.btnOpenBooks.Location = new System.Drawing.Point(60, 130);
            this.btnOpenBooks.Size = new System.Drawing.Size(320, 65);
            this.btnOpenBooks.Text = "📚 Books Process";
            this.btnOpenBooks.Click += new System.EventHandler(this.btnOpenBooks_Click);

            this.btnOpenCopies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnOpenCopies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenCopies.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenCopies.ForeColor = System.Drawing.Color.White;
            this.btnOpenCopies.Location = new System.Drawing.Point(420, 130);
            this.btnOpenCopies.Size = new System.Drawing.Size(320, 65);
            this.btnOpenCopies.Text = "📖 Book Copies Process";
            this.btnOpenCopies.Click += new System.EventHandler(this.btnOpenCopies_Click);

            this.btnOpenMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnOpenMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMembers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenMembers.ForeColor = System.Drawing.Color.White;
            this.btnOpenMembers.Location = new System.Drawing.Point(60, 220);
            this.btnOpenMembers.Size = new System.Drawing.Size(320, 65);
            this.btnOpenMembers.Text = "👥 Members Process";
            this.btnOpenMembers.Click += new System.EventHandler(this.btnOpenMembers_Click);

            this.btnOpenTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnOpenTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTransactions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenTransactions.ForeColor = System.Drawing.Color.White;
            this.btnOpenTransactions.Location = new System.Drawing.Point(420, 220);
            this.btnOpenTransactions.Size = new System.Drawing.Size(320, 65);
            this.btnOpenTransactions.Text = "💳 Borrow Transactions";
            this.btnOpenTransactions.Click += new System.EventHandler(this.btnOpenTransactions_Click);

            this.btnOpenReservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnOpenReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenReservations.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnOpenReservations.ForeColor = System.Drawing.Color.White;
            this.btnOpenReservations.Location = new System.Drawing.Point(240, 310);
            this.btnOpenReservations.Size = new System.Drawing.Size(320, 65);
            this.btnOpenReservations.Text = "📌 Reservations Process";
            this.btnOpenReservations.Click += new System.EventHandler(this.btnOpenReservations_Click);

            // 
            // FrmMain (Base White Background)
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnOpenBooks);
            this.Controls.Add(this.btnOpenCopies);
            this.Controls.Add(this.btnOpenMembers);
            this.Controls.Add(this.btnOpenTransactions);
            this.Controls.Add(this.btnOpenReservations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Lending System - Main Dashboard";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
