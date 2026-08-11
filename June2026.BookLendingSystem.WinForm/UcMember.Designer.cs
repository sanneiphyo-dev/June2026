namespace June2026.BookLendingSystem.WinForm
{
    partial class UcMember
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMembersViewHeader;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Button btnMembersRefresh;
        private System.Windows.Forms.Button btnMembersAdd;
        private System.Windows.Forms.Label lblMembersSearchLabel;
        private System.Windows.Forms.TextBox txtMembersSearch;

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
            lblMembersViewHeader = new Label();
            dgvMembers = new DataGridView();
            btnMembersRefresh = new Button();
            btnMembersAdd = new Button();
            lblMembersSearchLabel = new Label();
            txtMembersSearch = new TextBox();
            pnlPagination = new Panel();
            btnPrev = new Button();
            pnlPageNumbers = new FlowLayoutPanel();
            btnNext = new Button();
            lblPageInfo = new Label();
            lblTotalCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            pnlPagination.SuspendLayout();
            SuspendLayout();
            // 
            // lblMembersViewHeader
            // 
            lblMembersViewHeader.AutoSize = true;
            lblMembersViewHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblMembersViewHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblMembersViewHeader.Location = new Point(25, 15);
            lblMembersViewHeader.Name = "lblMembersViewHeader";
            lblMembersViewHeader.Size = new Size(321, 17);
            lblMembersViewHeader.TabIndex = 0;
            lblMembersViewHeader.Text = "Manage library patrons and administrative staff profiles.";
            // 
            // dgvMembers
            // 
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(241, 245, 249);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMembers.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(37, 99, 235);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMembers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMembers.EnableHeadersVisualStyles = false;
            dgvMembers.Location = new Point(25, 90);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.ReadOnly = true;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.Size = new Size(750, 345);
            dgvMembers.TabIndex = 1;
            // 
            // btnMembersRefresh
            // 
            btnMembersRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnMembersRefresh.FlatStyle = FlatStyle.Flat;
            btnMembersRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMembersRefresh.ForeColor = Color.White;
            btnMembersRefresh.Location = new Point(545, 45);
            btnMembersRefresh.Name = "btnMembersRefresh";
            btnMembersRefresh.Size = new Size(110, 30);
            btnMembersRefresh.TabIndex = 2;
            btnMembersRefresh.Text = "Refresh";
            btnMembersRefresh.UseVisualStyleBackColor = false;
            btnMembersRefresh.Click += btnMembersRefresh_Click;
            // 
            // btnMembersAdd
            // 
            btnMembersAdd.BackColor = Color.FromArgb(16, 185, 129);
            btnMembersAdd.FlatStyle = FlatStyle.Flat;
            btnMembersAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMembersAdd.ForeColor = Color.White;
            btnMembersAdd.Location = new Point(665, 45);
            btnMembersAdd.Name = "btnMembersAdd";
            btnMembersAdd.Size = new Size(110, 30);
            btnMembersAdd.TabIndex = 3;
            btnMembersAdd.Text = "+ Add Member";
            btnMembersAdd.UseVisualStyleBackColor = false;
            btnMembersAdd.Click += btnMembersAdd_Click;
            // 
            // lblMembersSearchLabel
            // 
            lblMembersSearchLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMembersSearchLabel.ForeColor = Color.FromArgb(71, 85, 105);
            lblMembersSearchLabel.Location = new Point(25, 50);
            lblMembersSearchLabel.Name = "lblMembersSearchLabel";
            lblMembersSearchLabel.Size = new Size(60, 20);
            lblMembersSearchLabel.TabIndex = 4;
            lblMembersSearchLabel.Text = "Search:";
            // 
            // txtMembersSearch
            // 
            txtMembersSearch.Font = new Font("Segoe UI", 9.5F);
            txtMembersSearch.Location = new Point(90, 46);
            txtMembersSearch.Name = "txtMembersSearch";
            txtMembersSearch.Size = new Size(250, 24);
            txtMembersSearch.TabIndex = 5;
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
            // UcMember
            // 
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(lblMembersViewHeader);
            Controls.Add(dgvMembers);
            Controls.Add(btnMembersRefresh);
            Controls.Add(btnMembersAdd);
            Controls.Add(lblMembersSearchLabel);
            Controls.Add(txtMembersSearch);
            Controls.Add(pnlPagination);
            Name = "UcMember";
            Size = new Size(804, 520);
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            pnlPagination.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
