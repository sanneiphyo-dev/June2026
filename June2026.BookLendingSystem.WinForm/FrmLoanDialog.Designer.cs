namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmLoanDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblMemberLabel;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label lblBookLabel;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label lblDueDateLabel;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.ComboBox cboStatus;
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
            lblMemberLabel = new Label();
            txtMemberId = new TextBox();
            lblBookLabel = new Label();
            txtBookTitle = new TextBox();
            lblDueDateLabel = new Label();
            dtpDueDate = new DateTimePicker();
            lblStatusLabel = new Label();
            cboStatus = new ComboBox();
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
            lblHeader.Text = "Lend Book Info";
            // 
            // lblMemberLabel
            // 
            lblMemberLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMemberLabel.Location = new Point(20, 60);
            lblMemberLabel.Name = "lblMemberLabel";
            lblMemberLabel.Size = new Size(360, 20);
            lblMemberLabel.TabIndex = 1;
            lblMemberLabel.Text = "Member ID:";
            // 
            // txtMemberId
            // 
            txtMemberId.Font = new Font("Segoe UI", 9.5F);
            txtMemberId.Location = new Point(20, 80);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(360, 24);
            txtMemberId.TabIndex = 2;
            // 
            // lblBookLabel
            // 
            lblBookLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBookLabel.Location = new Point(20, 120);
            lblBookLabel.Name = "lblBookLabel";
            lblBookLabel.Size = new Size(360, 20);
            lblBookLabel.TabIndex = 3;
            lblBookLabel.Text = "Book Title:";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Font = new Font("Segoe UI", 9.5F);
            txtBookTitle.Location = new Point(20, 140);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(360, 24);
            txtBookTitle.TabIndex = 4;
            // 
            // lblDueDateLabel
            // 
            lblDueDateLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDueDateLabel.Location = new Point(20, 180);
            lblDueDateLabel.Name = "lblDueDateLabel";
            lblDueDateLabel.Size = new Size(360, 20);
            lblDueDateLabel.TabIndex = 5;
            lblDueDateLabel.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Font = new Font("Segoe UI", 9.5F);
            dtpDueDate.Location = new Point(20, 200);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(360, 24);
            dtpDueDate.TabIndex = 6;
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatusLabel.Location = new Point(20, 240);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(360, 20);
            lblStatusLabel.TabIndex = 7;
            lblStatusLabel.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 9.5F);
            cboStatus.Items.AddRange(new object[] { "Borrowed", "Returned" });
            cboStatus.Location = new Point(20, 260);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(360, 25);
            cboStatus.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 310);
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
            btnCancel.Location = new Point(174, 310);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmLoanDialog
            // 
            AcceptButton = btnSave;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 365);
            Controls.Add(lblHeader);
            Controls.Add(lblMemberLabel);
            Controls.Add(txtMemberId);
            Controls.Add(lblBookLabel);
            Controls.Add(txtBookTitle);
            Controls.Add(lblDueDateLabel);
            Controls.Add(dtpDueDate);
            Controls.Add(lblStatusLabel);
            Controls.Add(cboStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLoanDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lend Book Dialog";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
