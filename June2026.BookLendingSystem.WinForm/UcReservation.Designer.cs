namespace June2026.BookLendingSystem.WinForm
{
    partial class UcReservation
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnResRefresh;
        private System.Windows.Forms.Button btnResAdd;
        private System.Windows.Forms.Label lblResSearchLabel;
        private System.Windows.Forms.TextBox txtResSearch;

        // Pagination Controls
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.FlowLayoutPanel pnlPageNumbers;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvReservations = new DataGridView();
            btnResRefresh = new Button();
            btnResAdd = new Button();
            lblResSearchLabel = new Label();
            txtResSearch = new TextBox();
            pnlPagination = new Panel();
            btnPrev = new Button();
            pnlPageNumbers = new FlowLayoutPanel();
            btnNext = new Button();
            lblPageInfo = new Label();
            lblTotalCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.White;
            dgvReservations.BorderStyle = BorderStyle.None;
            dgvReservations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReservations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservations.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvReservations.DefaultCellStyle = dataGridViewCellStyle2;
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.Location = new Point(25, 90);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(750, 345);
            dgvReservations.TabIndex = 1;
            // 
            // btnResRefresh
            // 
            btnResRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnResRefresh.FlatStyle = FlatStyle.Flat;
            btnResRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnResRefresh.ForeColor = Color.White;
            btnResRefresh.Location = new Point(545, 45);
            btnResRefresh.Name = "btnResRefresh";
            btnResRefresh.Size = new Size(110, 30);
            btnResRefresh.TabIndex = 2;
            btnResRefresh.Text = "Refresh";
            btnResRefresh.UseVisualStyleBackColor = false;
            btnResRefresh.Click += btnResRefresh_Click;
            // 
            // btnResAdd
            // 
            btnResAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnResAdd.FlatStyle = FlatStyle.Flat;
            btnResAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnResAdd.ForeColor = Color.White;
            btnResAdd.Location = new Point(665, 45);
            btnResAdd.Name = "btnResAdd";
            btnResAdd.Size = new Size(110, 30);
            btnResAdd.TabIndex = 3;
            btnResAdd.Text = "Place Hold";
            btnResAdd.UseVisualStyleBackColor = false;
            btnResAdd.Click += btnResAdd_Click;
            // 
            // lblResSearchLabel
            // 
            lblResSearchLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblResSearchLabel.ForeColor = Color.FromArgb(71, 85, 105);
            lblResSearchLabel.Location = new Point(25, 50);
            lblResSearchLabel.Name = "lblResSearchLabel";
            lblResSearchLabel.Size = new Size(60, 20);
            lblResSearchLabel.TabIndex = 4;
            lblResSearchLabel.Text = "Search:";
            // 
            // txtResSearch
            // 
            txtResSearch.Font = new Font("Segoe UI", 9.5F);
            txtResSearch.Location = new Point(90, 46);
            txtResSearch.Name = "txtResSearch";
            txtResSearch.Size = new Size(250, 24);
            txtResSearch.TabIndex = 5;
            // 
            // pnlPagination
            // 
            pnlPagination.Controls.Add(btnPrev);
            pnlPagination.Controls.Add(pnlPageNumbers);
            pnlPagination.Controls.Add(btnNext);
            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(lblTotalCount);
            pnlPagination.Location = new Point(25, 455);
            pnlPagination.Name = "pnlPagination";
            pnlPagination.Size = new Size(750, 45);
            pnlPagination.TabIndex = 6;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.White;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(71, 85, 105);
            btnPrev.Location = new Point(0, 5);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(35, 25);
            btnPrev.TabIndex = 0;
            btnPrev.Text = "◀";
            btnPrev.UseVisualStyleBackColor = false;
            // 
            // pnlPageNumbers
            // 
            pnlPageNumbers.Location = new Point(45, 5);
            pnlPageNumbers.Name = "pnlPageNumbers";
            pnlPageNumbers.Size = new Size(300, 25);
            pnlPageNumbers.TabIndex = 1;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.White;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(71, 85, 105);
            btnNext.Location = new Point(355, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(35, 25);
            btnNext.TabIndex = 2;
            btnNext.Text = "▶";
            btnNext.UseVisualStyleBackColor = false;
            // 
            // lblPageInfo
            // 
            lblPageInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPageInfo.ForeColor = Color.FromArgb(71, 85, 105);
            lblPageInfo.Location = new Point(410, 8);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(120, 20);
            lblPageInfo.TabIndex = 3;
            lblPageInfo.Text = "Page 1 of 1";
            // 
            // lblTotalCount
            // 
            lblTotalCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTotalCount.ForeColor = Color.FromArgb(71, 85, 105);
            lblTotalCount.Location = new Point(540, 8);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(210, 20);
            lblTotalCount.TabIndex = 4;
            lblTotalCount.Text = "Total: 0 records";
            lblTotalCount.TextAlign = ContentAlignment.TopRight;
            // 
            // UcReservation
            // 
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(dgvReservations);
            Controls.Add(btnResRefresh);
            Controls.Add(btnResAdd);
            Controls.Add(lblResSearchLabel);
            Controls.Add(txtResSearch);
            Controls.Add(pnlPagination);
            Name = "UcReservation";
            Size = new Size(804, 520);
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            pnlPagination.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
