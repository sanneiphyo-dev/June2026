namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmMember
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvMembers;

        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;

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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();

            this.lblMemberId = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();

            // Header (Royal Blue)
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 60);

            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Text = "Members Management Process";

            // GridView
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(20, 80);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.Size = new System.Drawing.Size(520, 420);
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembers_CellClick);

            // Inputs
            this.lblMemberId.Location = new System.Drawing.Point(560, 75);
            this.lblMemberId.Text = "Member ID (e.g. MEM-1082):";
            this.txtMemberId.Location = new System.Drawing.Point(560, 95);
            this.txtMemberId.Size = new System.Drawing.Size(310, 25);

            this.lblFullName.Location = new System.Drawing.Point(560, 125);
            this.lblFullName.Text = "Full Name:";
            this.txtFullName.Location = new System.Drawing.Point(560, 145);
            this.txtFullName.Size = new System.Drawing.Size(310, 25);

            this.lblEmail.Location = new System.Drawing.Point(560, 175);
            this.lblEmail.Text = "Email:";
            this.txtEmail.Location = new System.Drawing.Point(560, 195);
            this.txtEmail.Size = new System.Drawing.Size(310, 25);

            this.lblPhone.Location = new System.Drawing.Point(560, 225);
            this.lblPhone.Text = "Phone:";
            this.txtPhone.Location = new System.Drawing.Point(560, 245);
            this.txtPhone.Size = new System.Drawing.Size(310, 25);

            this.lblRole.Location = new System.Drawing.Point(560, 275);
            this.lblRole.Text = "Role (Student/Teacher):";
            this.txtRole.Location = new System.Drawing.Point(560, 295);
            this.txtRole.Size = new System.Drawing.Size(310, 25);

            this.lblStatus.Location = new System.Drawing.Point(560, 325);
            this.lblStatus.Text = "Status (Active/Inactive):";
            this.txtStatus.Location = new System.Drawing.Point(560, 345);
            this.txtStatus.Size = new System.Drawing.Size(310, 25);

            // Buttons
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(560, 390);
            this.btnRefresh.Size = new System.Drawing.Size(145, 35);
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(725, 390);
            this.btnAdd.Size = new System.Drawing.Size(145, 35);
            this.btnAdd.Text = "Add Member";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(560, 435);
            this.btnUpdate.Size = new System.Drawing.Size(145, 35);
            this.btnUpdate.Text = "Update Member";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(725, 435);
            this.btnDelete.Size = new System.Drawing.Size(145, 35);
            this.btnDelete.Text = "Delete Member";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(560, 475);
            this.btnClear.Size = new System.Drawing.Size(310, 25);
            this.btnClear.Text = "Clear Form";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Form
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvMembers);
            this.Controls.Add(this.lblMemberId);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Name = "FrmMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Members Process - HttpClient";
            this.Load += new System.EventHandler(this.FrmMember_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
