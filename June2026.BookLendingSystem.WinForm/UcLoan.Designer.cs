namespace June2026.BookLendingSystem.WinForm
{
    partial class UcLoan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTransactionsViewHeader;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Label lblTxnMemberIdLabel;
        private System.Windows.Forms.TextBox txtTxnMemberId;
        private System.Windows.Forms.Button btnTxnRefresh;
        private System.Windows.Forms.Button btnTxnBorrow;

        // Pagination Controls
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.FlowLayoutPanel pnlPageNumbers;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;

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
            this.lblTransactionsViewHeader = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.lblTxnMemberIdLabel = new System.Windows.Forms.Label();
            this.txtTxnMemberId = new System.Windows.Forms.TextBox();
            this.btnTxnRefresh = new System.Windows.Forms.Button();
            this.btnTxnBorrow = new System.Windows.Forms.Button();

            // Pagination Controls
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlPageNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTransactionsViewHeader
            // 
            this.lblTransactionsViewHeader.AutoSize = true;
            this.lblTransactionsViewHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTransactionsViewHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTransactionsViewHeader.Location = new System.Drawing.Point(25, 15);
            this.lblTransactionsViewHeader.Name = "lblTransactionsViewHeader";
            this.lblTransactionsViewHeader.Size = new System.Drawing.Size(287, 17);
            this.lblTransactionsViewHeader.Text = "Filter active loans and log history using search.";

            // 
            // lblTxnMemberIdLabel
            // 
            this.lblTxnMemberIdLabel.Location = new System.Drawing.Point(25, 50);
            this.lblTxnMemberIdLabel.Name = "lblTxnMemberIdLabel";
            this.lblTxnMemberIdLabel.Size = new System.Drawing.Size(60, 20);
            this.lblTxnMemberIdLabel.Text = "Search:";
            this.lblTxnMemberIdLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTxnMemberIdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));

            // 
            // txtTxnMemberId
            // 
            this.txtTxnMemberId.Location = new System.Drawing.Point(90, 46);
            this.txtTxnMemberId.Name = "txtTxnMemberId";
            this.txtTxnMemberId.Size = new System.Drawing.Size(250, 23);
            this.txtTxnMemberId.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // 
            // btnTxnRefresh
            // 
            this.btnTxnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnTxnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTxnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTxnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnTxnRefresh.Location = new System.Drawing.Point(545, 45);
            this.btnTxnRefresh.Name = "btnTxnRefresh";
            this.btnTxnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnTxnRefresh.Text = "Refresh";
            this.btnTxnRefresh.Click += new System.EventHandler(this.btnTxnRefresh_Click);

            // 
            // btnTxnBorrow
            // 
            this.btnTxnBorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnTxnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTxnBorrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTxnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnTxnBorrow.Location = new System.Drawing.Point(665, 45);
            this.btnTxnBorrow.Name = "btnTxnBorrow";
            this.btnTxnBorrow.Size = new System.Drawing.Size(110, 30);
            this.btnTxnBorrow.Text = "Lend Book";
            this.btnTxnBorrow.Click += new System.EventHandler(this.btnTxnBorrow_Click);

            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.Location = new System.Drawing.Point(25, 90);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(750, 345);
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvTransactions.ColumnHeadersHeight = 35;
            this.dgvTransactions.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvTransactions.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.dgvTransactions.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Controls.Add(this.pnlPageNumbers);
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Controls.Add(this.lblPageInfo);
            this.pnlPagination.Controls.Add(this.lblTotalCount);
            this.pnlPagination.Location = new System.Drawing.Point(25, 455);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(750, 45);

            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPrev.Location = new System.Drawing.Point(0, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 25);
            this.btnPrev.Text = "◀";
            this.btnPrev.UseVisualStyleBackColor = false;

            // 
            // pnlPageNumbers
            // 
            this.pnlPageNumbers.Location = new System.Drawing.Point(45, 5);
            this.pnlPageNumbers.Name = "pnlPageNumbers";
            this.pnlPageNumbers.Size = new System.Drawing.Size(300, 25);

            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnNext.Location = new System.Drawing.Point(355, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 25);
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = false;

            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPageInfo.Location = new System.Drawing.Point(410, 8);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(120, 20);
            this.lblPageInfo.Text = "Page 1 of 1";

            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTotalCount.Location = new System.Drawing.Point(540, 8);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(210, 20);
            this.lblTotalCount.Text = "Total: 0 records";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // UcLoan
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.lblTransactionsViewHeader);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnTxnRefresh);
            this.Controls.Add(this.btnTxnBorrow);
            this.Controls.Add(this.lblTxnMemberIdLabel);
            this.Controls.Add(this.txtTxnMemberId);
            this.Controls.Add(this.pnlPagination);
            this.Name = "UcLoan";
            this.Size = new System.Drawing.Size(804, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
