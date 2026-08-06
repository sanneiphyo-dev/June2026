namespace June2026.BookLendingSystem.WinForm
{
    partial class FrmReservation
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvReservations;

        private System.Windows.Forms.Label lblResId;
        private System.Windows.Forms.TextBox txtResId;
        private System.Windows.Forms.Label lblBookId;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.TextBox txtMemberId;
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
            this.dgvReservations = new System.Windows.Forms.DataGridView();

            this.lblResId = new System.Windows.Forms.Label();
            this.txtResId = new System.Windows.Forms.TextBox();
            this.lblBookId = new System.Windows.Forms.Label();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
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
            this.lblHeaderTitle.Text = "Reservations Waiting List Process";

            // GridView
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(20, 80);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(520, 420);
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservations_CellClick);

            // Inputs
            this.lblResId.Location = new System.Drawing.Point(560, 80);
            this.lblResId.Text = "Reservation ID:";
            this.txtResId.Location = new System.Drawing.Point(560, 100);
            this.txtResId.Size = new System.Drawing.Size(310, 25);
            this.txtResId.ReadOnly = true;
            this.txtResId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));

            this.lblBookId.Location = new System.Drawing.Point(560, 140);
            this.lblBookId.Text = "Book ID:";
            this.txtBookId.Location = new System.Drawing.Point(560, 160);
            this.txtBookId.Size = new System.Drawing.Size(310, 25);

            this.lblMemberId.Location = new System.Drawing.Point(560, 200);
            this.lblMemberId.Text = "Member ID:";
            this.txtMemberId.Location = new System.Drawing.Point(560, 220);
            this.txtMemberId.Size = new System.Drawing.Size(310, 25);

            this.lblStatus.Location = new System.Drawing.Point(560, 260);
            this.lblStatus.Text = "Status (Pending/Fulfilled/Cancelled):";
            this.txtStatus.Location = new System.Drawing.Point(560, 280);
            this.txtStatus.Size = new System.Drawing.Size(310, 25);

            // Buttons
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(560, 330);
            this.btnRefresh.Size = new System.Drawing.Size(145, 35);
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(725, 330);
            this.btnAdd.Size = new System.Drawing.Size(145, 35);
            this.btnAdd.Text = "Reserve Book";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(560, 380);
            this.btnUpdate.Size = new System.Drawing.Size(145, 35);
            this.btnUpdate.Text = "Update Status";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(725, 380);
            this.btnDelete.Size = new System.Drawing.Size(145, 35);
            this.btnDelete.Text = "Delete Reservation";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(560, 430);
            this.btnClear.Size = new System.Drawing.Size(310, 30);
            this.btnClear.Text = "Clear Form";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // Form
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvReservations);
            this.Controls.Add(this.lblResId);
            this.Controls.Add(this.txtResId);
            this.Controls.Add(this.lblBookId);
            this.Controls.Add(this.txtBookId);
            this.Controls.Add(this.lblMemberId);
            this.Controls.Add(this.txtMemberId);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Name = "FrmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservations Process - HttpClient";
            this.Load += new System.EventHandler(this.FrmReservation_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
