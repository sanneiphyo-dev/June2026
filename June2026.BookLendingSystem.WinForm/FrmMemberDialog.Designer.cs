namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmMemberDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblMemberIdLabel;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label lblNameLabel;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmailLabel;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhoneLabel;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRoleLabel;
        private System.Windows.Forms.TextBox txtRole;
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
            lblMemberIdLabel = new Label();
            txtMemberId = new TextBox();
            lblNameLabel = new Label();
            txtFullName = new TextBox();
            lblEmailLabel = new Label();
            txtEmail = new TextBox();
            lblPhoneLabel = new Label();
            txtPhone = new TextBox();
            lblRoleLabel = new Label();
            txtRole = new TextBox();
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
            lblHeader.TabIndex = 99;
            lblHeader.Text = "Patron Profile Info";
            // 
            // lblMemberIdLabel
            // 
            lblMemberIdLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMemberIdLabel.Location = new Point(20, 60);
            lblMemberIdLabel.Name = "lblMemberIdLabel";
            lblMemberIdLabel.Size = new Size(360, 20);
            lblMemberIdLabel.TabIndex = 13;
            lblMemberIdLabel.Text = "Member ID:";
            // 
            // txtMemberId
            // 
            txtMemberId.Font = new Font("Segoe UI", 9.5F);
            txtMemberId.Location = new Point(20, 80);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(360, 24);
            txtMemberId.TabIndex = 0;
            // 
            // lblNameLabel
            // 
            lblNameLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNameLabel.Location = new Point(20, 120);
            lblNameLabel.Name = "lblNameLabel";
            lblNameLabel.Size = new Size(360, 20);
            lblNameLabel.TabIndex = 1;
            lblNameLabel.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.Location = new Point(20, 140);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(360, 24);
            txtFullName.TabIndex = 1;
            // 
            // lblEmailLabel
            // 
            lblEmailLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmailLabel.Location = new Point(20, 180);
            lblEmailLabel.Name = "lblEmailLabel";
            lblEmailLabel.Size = new Size(360, 20);
            lblEmailLabel.TabIndex = 3;
            lblEmailLabel.Text = "Email Address:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(20, 200);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 24);
            txtEmail.TabIndex = 2;
            // 
            // lblPhoneLabel
            // 
            lblPhoneLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPhoneLabel.Location = new Point(20, 240);
            lblPhoneLabel.Name = "lblPhoneLabel";
            lblPhoneLabel.Size = new Size(360, 20);
            lblPhoneLabel.TabIndex = 5;
            lblPhoneLabel.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.Location = new Point(20, 260);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(360, 24);
            txtPhone.TabIndex = 3;
            // 
            // lblRoleLabel
            // 
            lblRoleLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRoleLabel.Location = new Point(20, 300);
            lblRoleLabel.Name = "lblRoleLabel";
            lblRoleLabel.Size = new Size(360, 20);
            lblRoleLabel.TabIndex = 7;
            lblRoleLabel.Text = "Role :";
            // 
            // txtRole
            // 
            txtRole.Font = new Font("Segoe UI", 9.5F);
            txtRole.Location = new Point(20, 320);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(360, 24);
            txtRole.TabIndex = 4;
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatusLabel.Location = new Point(20, 360);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(360, 20);
            lblStatusLabel.TabIndex = 9;
            lblStatusLabel.Text = "Registry Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 9.5F);
            cboStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cboStatus.Location = new Point(20, 380);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(360, 25);
            cboStatus.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 436);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 6;
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
            btnCancel.Location = new Point(174, 436);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmMemberDialog
            // 
            AcceptButton = btnSave;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 495);
            Controls.Add(lblHeader);
            Controls.Add(lblMemberIdLabel);
            Controls.Add(txtMemberId);
            Controls.Add(lblNameLabel);
            Controls.Add(txtFullName);
            Controls.Add(lblEmailLabel);
            Controls.Add(txtEmail);
            Controls.Add(lblPhoneLabel);
            Controls.Add(txtPhone);
            Controls.Add(lblRoleLabel);
            Controls.Add(txtRole);
            Controls.Add(lblStatusLabel);
            Controls.Add(cboStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMemberDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Member Profile Dialog";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
