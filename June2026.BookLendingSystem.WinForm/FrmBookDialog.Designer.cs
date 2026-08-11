namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmBookDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitleLabel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAuthorLabel;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblPublisherLabel;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblCategoryLabel;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            lblHeader = new Label();
            lblTitleLabel = new Label();
            txtTitle = new TextBox();
            lblAuthorLabel = new Label();
            txtAuthor = new TextBox();
            lblPublisherLabel = new Label();
            txtPublisher = new TextBox();
            lblCategoryLabel = new Label();
            txtCategory = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblHeader.Location = new Point(20, 15);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(380, 30);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Book Info";
            // 
            // lblTitleLabel
            // 
            lblTitleLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTitleLabel.Location = new Point(20, 60);
            lblTitleLabel.Name = "lblTitleLabel";
            lblTitleLabel.Size = new Size(360, 20);
            lblTitleLabel.TabIndex = 1;
            lblTitleLabel.Text = "Book Title:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 9.5F);
            txtTitle.Location = new Point(20, 80);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(360, 24);
            txtTitle.TabIndex = 2;
            // 
            // lblAuthorLabel
            // 
            lblAuthorLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAuthorLabel.Location = new Point(20, 120);
            lblAuthorLabel.Name = "lblAuthorLabel";
            lblAuthorLabel.Size = new Size(360, 20);
            lblAuthorLabel.TabIndex = 3;
            lblAuthorLabel.Text = "Author:";
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 9.5F);
            txtAuthor.Location = new Point(20, 140);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(360, 24);
            txtAuthor.TabIndex = 4;
            // 
            // lblPublisherLabel
            // 
            lblPublisherLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPublisherLabel.Location = new Point(20, 180);
            lblPublisherLabel.Name = "lblPublisherLabel";
            lblPublisherLabel.Size = new Size(360, 20);
            lblPublisherLabel.TabIndex = 5;
            lblPublisherLabel.Text = "Publisher:";
            // 
            // txtPublisher
            // 
            txtPublisher.Font = new Font("Segoe UI", 9.5F);
            txtPublisher.Location = new Point(20, 200);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(360, 24);
            txtPublisher.TabIndex = 6;
            // 
            // lblCategoryLabel
            // 
            lblCategoryLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategoryLabel.Location = new Point(20, 240);
            lblCategoryLabel.Name = "lblCategoryLabel";
            lblCategoryLabel.Size = new Size(360, 20);
            lblCategoryLabel.TabIndex = 7;
            lblCategoryLabel.Text = "Category:";
            // 
            // txtCategory
            // 
            txtCategory.Font = new Font("Segoe UI", 9.5F);
            txtCategory.Location = new Point(20, 260);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(360, 24);
            txtCategory.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 321);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(100, 116, 139);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(174, 321);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmBookDialog
            // 
            AcceptButton = btnSave;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 385);
            Controls.Add(lblHeader);
            Controls.Add(lblTitleLabel);
            Controls.Add(txtTitle);
            Controls.Add(lblAuthorLabel);
            Controls.Add(txtAuthor);
            Controls.Add(lblPublisherLabel);
            Controls.Add(txtPublisher);
            Controls.Add(lblCategoryLabel);
            Controls.Add(txtCategory);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmBookDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Book Dialog";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
