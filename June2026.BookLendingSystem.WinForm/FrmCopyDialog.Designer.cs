namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmCopyDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblBookTitleLabel;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label lblCopyCountLabel;
        private System.Windows.Forms.TextBox txtCopyCount;
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
            lblBookTitleLabel = new Label();
            txtBookTitle = new TextBox();
            lblCopyCountLabel = new Label();
            txtCopyCount = new TextBox();
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
            lblHeader.Text = "Book Copy Info";
            // 
            // lblBookTitleLabel
            // 
            lblBookTitleLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBookTitleLabel.Location = new Point(20, 60);
            lblBookTitleLabel.Name = "lblBookTitleLabel";
            lblBookTitleLabel.Size = new Size(360, 20);
            lblBookTitleLabel.TabIndex = 1;
            lblBookTitleLabel.Text = "Book Title:";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Font = new Font("Segoe UI", 9.5F);
            txtBookTitle.Location = new Point(20, 80);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(360, 24);
            txtBookTitle.TabIndex = 2;
            // 
            // lblCopyCountLabel
            // 
            lblCopyCountLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCopyCountLabel.Location = new Point(20, 120);
            lblCopyCountLabel.Name = "lblCopyCountLabel";
            lblCopyCountLabel.Size = new Size(360, 20);
            lblCopyCountLabel.TabIndex = 3;
            lblCopyCountLabel.Text = "Copy :";
            lblCopyCountLabel.Click += lblCopyCountLabel_Click;
            // 
            // txtCopyCount
            // 
            txtCopyCount.Font = new Font("Segoe UI", 9.5F);
            txtCopyCount.Location = new Point(20, 140);
            txtCopyCount.Name = "txtCopyCount";
            txtCopyCount.Size = new Size(360, 24);
            txtCopyCount.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 190);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 5;
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
            btnCancel.Location = new Point(174, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmCopyDialog
            // 
            AcceptButton = btnSave;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 255);
            Controls.Add(lblHeader);
            Controls.Add(lblBookTitleLabel);
            Controls.Add(txtBookTitle);
            Controls.Add(lblCopyCountLabel);
            Controls.Add(txtCopyCount);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCopyDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Book Copy Dialog";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
