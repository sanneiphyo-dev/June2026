namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmReservationDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblBookLabel;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label lblMemberLabel;
        private System.Windows.Forms.TextBox txtMemberId;
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
            lblBookLabel = new Label();
            txtBookId = new TextBox();
            lblMemberLabel = new Label();
            txtMemberId = new TextBox();
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
            lblHeader.Text = "Book Hold Info";
            // 
            // lblBookLabel
            // 
            lblBookLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBookLabel.Location = new Point(20, 60);
            lblBookLabel.Name = "lblBookLabel";
            lblBookLabel.Size = new Size(360, 20);
            lblBookLabel.TabIndex = 1;
            lblBookLabel.Text = "Book Title:";
            lblBookLabel.Click += lblBookLabel_Click;
            // 
            // txtBookId
            // 
            txtBookId.Font = new Font("Segoe UI", 9.5F);
            txtBookId.Location = new Point(20, 80);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(360, 24);
            txtBookId.TabIndex = 2;
            // 
            // lblMemberLabel
            // 
            lblMemberLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMemberLabel.Location = new Point(20, 120);
            lblMemberLabel.Name = "lblMemberLabel";
            lblMemberLabel.Size = new Size(360, 20);
            lblMemberLabel.TabIndex = 3;
            lblMemberLabel.Text = "Member ID:";
            // 
            // txtMemberId
            // 
            txtMemberId.Font = new Font("Segoe UI", 9.5F);
            txtMemberId.Location = new Point(20, 140);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(360, 24);
            txtMemberId.TabIndex = 4;
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStatusLabel.Location = new Point(20, 180);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(360, 20);
            lblStatusLabel.TabIndex = 5;
            lblStatusLabel.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 9.5F);
            cboStatus.Items.AddRange(new object[] { "Pending", "Approved", "Cancelled", "Completed" });
            cboStatus.Location = new Point(20, 200);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(360, 25);
            cboStatus.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 7;
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
            btnCancel.Location = new Point(174, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmReservationDialog
            // 
            AcceptButton = btnSave;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 305);
            Controls.Add(lblHeader);
            Controls.Add(lblBookLabel);
            Controls.Add(txtBookId);
            Controls.Add(lblMemberLabel);
            Controls.Add(txtMemberId);
            Controls.Add(lblStatusLabel);
            Controls.Add(cboStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmReservationDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reservation Hold Dialog";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
