namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmBook
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtCategory;

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
            dgvBooks = new DataGridView();
            lblBookId = new Label();
            txtBookId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblPublisher = new Label();
            txtPublisher = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            btnRefresh = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
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
            lblHeaderTitle.Size = new Size(294, 30);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Book Management Process";
            // 
            // dgvBooks
            // 
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(20, 80);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(520, 420);
            dgvBooks.TabIndex = 1;
            dgvBooks.CellClick += dgvBooks_CellClick;
            // 
            // lblBookId
            // 
            lblBookId.Location = new Point(560, 74);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(100, 23);
            lblBookId.TabIndex = 2;
            lblBookId.Text = "Book ID:";
            // 
            // txtBookId
            // 
            txtBookId.BackColor = Color.FromArgb(243, 244, 246);
            txtBookId.Location = new Point(560, 100);
            txtBookId.Name = "txtBookId";
            txtBookId.ReadOnly = true;
            txtBookId.Size = new Size(310, 23);
            txtBookId.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(560, 129);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(560, 155);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(310, 23);
            txtTitle.TabIndex = 5;
            // 
            // lblAuthor
            // 
            lblAuthor.Location = new Point(560, 184);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(100, 23);
            lblAuthor.TabIndex = 6;
            lblAuthor.Text = "Author:";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(560, 210);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(310, 23);
            txtAuthor.TabIndex = 7;
            // 
            // lblPublisher
            // 
            lblPublisher.Location = new Point(560, 239);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(100, 23);
            lblPublisher.TabIndex = 8;
            lblPublisher.Text = "Publisher:";
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(560, 265);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(310, 23);
            txtPublisher.TabIndex = 9;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(560, 294);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 10;
            lblCategory.Text = "Category:";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(560, 320);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(310, 23);
            txtCategory.TabIndex = 11;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(560, 370);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(145, 35);
            btnRefresh.TabIndex = 12;
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
            btnAdd.Location = new Point(725, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 35);
            btnAdd.TabIndex = 13;
            btnAdd.Text = "Add Book";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(30, 64, 175);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(560, 420);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 35);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update Book";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(225, 29, 72);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(725, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 35);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete Book";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(560, 465);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(310, 30);
            btnClear.TabIndex = 16;
            btnClear.Text = "Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // FrmBook
            // 
            BackColor = Color.White;
            ClientSize = new Size(900, 520);
            Controls.Add(pnlHeader);
            Controls.Add(dgvBooks);
            Controls.Add(lblBookId);
            Controls.Add(txtBookId);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblAuthor);
            Controls.Add(txtAuthor);
            Controls.Add(lblPublisher);
            Controls.Add(txtPublisher);
            Controls.Add(lblCategory);
            Controls.Add(txtCategory);
            Controls.Add(btnRefresh);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Name = "FrmBook";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Book Management Process - HttpClient";
            Load += FrmBook_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
