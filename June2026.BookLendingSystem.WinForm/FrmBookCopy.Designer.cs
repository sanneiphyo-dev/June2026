namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmBookCopy
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvCopies;

        private System.Windows.Forms.Label lblCopyId;
        private System.Windows.Forms.TextBox txtCopyId;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCount;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
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
            dgvCopies = new DataGridView();
            lblCopyId = new Label();
            txtCopyId = new TextBox();
            lblBookId = new Label();
            txtBookId = new TextBox();
            lblCount = new Label();
            txtCount = new TextBox();
            btnRefresh = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCopies).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 64, 175);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(900, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 15);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(369, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Book Copies Management Process";
            // 
            // dgvCopies
            // 
            dgvCopies.BackgroundColor = Color.White;
            dgvCopies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCopies.Location = new Point(20, 80);
            dgvCopies.Name = "dgvCopies";
            dgvCopies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCopies.Size = new Size(520, 420);
            dgvCopies.TabIndex = 1;
            dgvCopies.CellClick += dgvCopies_CellClick;
            // 
            // lblCopyId
            // 
            lblCopyId.Location = new Point(560, 74);
            lblCopyId.Name = "lblCopyId";
            lblCopyId.Size = new Size(100, 23);
            lblCopyId.TabIndex = 2;
            lblCopyId.Text = "Copy ID (e.g. CC-COPY-01):";
            // 
            // txtCopyId
            // 
            txtCopyId.Location = new Point(560, 100);
            txtCopyId.Name = "txtCopyId";
            txtCopyId.Size = new Size(310, 23);
            txtCopyId.TabIndex = 3;
            // 
            // lblBookId
            // 
            lblBookId.Location = new Point(560, 134);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(100, 23);
            lblBookId.TabIndex = 4;
            lblBookId.Text = "Book ID:";
            // 
            // txtBookId
            // 
            txtBookId.Location = new Point(560, 160);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(310, 23);
            txtBookId.TabIndex = 5;
            // 
            // lblCount
            // 
            lblCount.Location = new Point(560, 194);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(100, 23);
            lblCount.TabIndex = 6;
            lblCount.Text = "Copy Count / Label:";
            // 
            // txtCount
            // 
            txtCount.Location = new Point(560, 220);
            txtCount.Name = "txtCount";
            txtCount.Size = new Size(310, 23);
            txtCount.TabIndex = 7;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(560, 280);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(145, 35);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(37, 99, 235);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(725, 280);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 35);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add Copy";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(30, 64, 175);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(560, 330);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 35);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update Copy";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(225, 29, 72);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(725, 330);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 35);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete Copy";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(560, 380);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(310, 30);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // FrmBookCopy
            // 
            BackColor = Color.White;
            ClientSize = new Size(900, 520);
            Controls.Add(pnlHeader);
            Controls.Add(dgvCopies);
            Controls.Add(lblCopyId);
            Controls.Add(txtCopyId);
            Controls.Add(lblBookId);
            Controls.Add(txtBookId);
            Controls.Add(lblCount);
            Controls.Add(txtCount);
            Controls.Add(btnRefresh);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Name = "FrmBookCopy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Copies Process - HttpClient";
            Load += FrmBookCopy_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCopies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
