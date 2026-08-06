namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmBorrowTransaction
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvTransactions;

        private System.Windows.Forms.Label lblTxnId;
        private System.Windows.Forms.TextBox txtTxnId;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label lblCopyId;
        private System.Windows.Forms.TextBox txtCopyId;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblFineAmount;
        private System.Windows.Forms.TextBox txtFineAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

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
            pnlHeader = new Panel();
            lblHeaderTitle = new Label();
            dgvTransactions = new DataGridView();
            lblTxnId = new Label();
            txtTxnId = new TextBox();
            lblMemberId = new Label();
            txtMemberId = new TextBox();
            lblCopyId = new Label();
            txtCopyId = new TextBox();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            lblFineAmount = new Label();
            txtFineAmount = new TextBox();
            lblStatus = new Label();
            txtStatus = new TextBox();
            btnRefresh = new Button();
            btnBorrow = new Button();
            btnReturn = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 64, 175);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(920, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 15);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(309, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Borrow Transactions Process";
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(20, 80);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(540, 420);
            dgvTransactions.TabIndex = 1;
            dgvTransactions.CellClick += dgvTransactions_CellClick;
            // 
            // lblTxnId
            // 
            lblTxnId.Location = new Point(580, 69);
            lblTxnId.Name = "lblTxnId";
            lblTxnId.Size = new Size(100, 23);
            lblTxnId.TabIndex = 2;
            lblTxnId.Text = "Txn ID (e.g. TXN-2026-0089):";
            // 
            // txtTxnId
            // 
            txtTxnId.Location = new Point(580, 95);
            txtTxnId.Name = "txtTxnId";
            txtTxnId.Size = new Size(310, 23);
            txtTxnId.TabIndex = 3;
            // 
            // lblMemberId
            // 
            lblMemberId.Location = new Point(580, 119);
            lblMemberId.Name = "lblMemberId";
            lblMemberId.Size = new Size(100, 23);
            lblMemberId.TabIndex = 4;
            lblMemberId.Text = "Member ID:";
            // 
            // txtMemberId
            // 
            txtMemberId.Location = new Point(580, 145);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(310, 23);
            txtMemberId.TabIndex = 5;
            // 
            // lblCopyId
            // 
            lblCopyId.Location = new Point(580, 169);
            lblCopyId.Name = "lblCopyId";
            lblCopyId.Size = new Size(100, 23);
            lblCopyId.TabIndex = 6;
            lblCopyId.Text = "Copy ID:";
            // 
            // txtCopyId
            // 
            txtCopyId.Location = new Point(580, 195);
            txtCopyId.Name = "txtCopyId";
            txtCopyId.Size = new Size(310, 23);
            txtCopyId.TabIndex = 7;
            // 
            // lblDueDate
            // 
            lblDueDate.Location = new Point(580, 219);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(100, 23);
            lblDueDate.TabIndex = 8;
            lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(580, 245);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(310, 23);
            dtpDueDate.TabIndex = 9;
            // 
            // lblFineAmount
            // 
            lblFineAmount.Location = new Point(580, 269);
            lblFineAmount.Name = "lblFineAmount";
            lblFineAmount.Size = new Size(100, 23);
            lblFineAmount.TabIndex = 10;
            lblFineAmount.Text = "Fine Amount ($):";
            // 
            // txtFineAmount
            // 
            txtFineAmount.Location = new Point(580, 295);
            txtFineAmount.Name = "txtFineAmount";
            txtFineAmount.Size = new Size(310, 23);
            txtFineAmount.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(580, 321);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status (Borrowed/Returned):";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(580, 345);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(310, 23);
            txtStatus.TabIndex = 13;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(580, 390);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(145, 35);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.FromArgb(37, 99, 235);
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBorrow.ForeColor = Color.White;
            btnBorrow.Location = new Point(745, 390);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(145, 35);
            btnBorrow.TabIndex = 15;
            btnBorrow.Text = "Borrow Book";
            btnBorrow.UseVisualStyleBackColor = false;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(16, 185, 129);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(580, 435);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(145, 35);
            btnReturn.TabIndex = 16;
            btnReturn.Text = "Mark Returned";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(225, 29, 72);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(745, 435);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 35);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete Transaction";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(580, 475);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(310, 25);
            btnClear.TabIndex = 18;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // FrmBorrowTransaction
            // 
            BackColor = Color.White;
            ClientSize = new Size(920, 520);
            Controls.Add(pnlHeader);
            Controls.Add(dgvTransactions);
            Controls.Add(lblTxnId);
            Controls.Add(txtTxnId);
            Controls.Add(lblMemberId);
            Controls.Add(txtMemberId);
            Controls.Add(lblCopyId);
            Controls.Add(txtCopyId);
            Controls.Add(lblDueDate);
            Controls.Add(dtpDueDate);
            Controls.Add(lblFineAmount);
            Controls.Add(txtFineAmount);
            Controls.Add(lblStatus);
            Controls.Add(txtStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnBorrow);
            Controls.Add(btnReturn);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Name = "FrmBorrowTransaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borrow Transactions Process - HttpClient";
            Load += FrmBorrowTransaction_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
