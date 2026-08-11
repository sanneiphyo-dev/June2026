namespace June2026.BookLendingSystem.WinForm
{
    partial class UcCopy
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCopiesViewHeader;
        private System.Windows.Forms.DataGridView dgvCopies;
        private System.Windows.Forms.Button btnCopiesRefresh;
        private System.Windows.Forms.Button btnCopiesAdd;
        private System.Windows.Forms.Label lblCopiesSearchLabel;
        private System.Windows.Forms.TextBox txtCopiesSearch;

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
            this.lblCopiesViewHeader = new System.Windows.Forms.Label();
            this.dgvCopies = new System.Windows.Forms.DataGridView();
            this.btnCopiesRefresh = new System.Windows.Forms.Button();
            this.btnCopiesAdd = new System.Windows.Forms.Button();
            this.lblCopiesSearchLabel = new System.Windows.Forms.Label();
            this.txtCopiesSearch = new System.Windows.Forms.TextBox();

            // Pagination Controls
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlPageNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblCopiesViewHeader
            // 
            this.lblCopiesViewHeader.AutoSize = true;
            this.lblCopiesViewHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblCopiesViewHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCopiesViewHeader.Location = new System.Drawing.Point(25, 15);
            this.lblCopiesViewHeader.Name = "lblCopiesViewHeader";
            this.lblCopiesViewHeader.Size = new System.Drawing.Size(296, 17);
            this.lblCopiesViewHeader.Text = "Manage physical inventory stock counts per title.";

            // 
            // lblCopiesSearchLabel
            // 
            this.lblCopiesSearchLabel.Location = new System.Drawing.Point(25, 50);
            this.lblCopiesSearchLabel.Name = "lblCopiesSearchLabel";
            this.lblCopiesSearchLabel.Size = new System.Drawing.Size(60, 20);
            this.lblCopiesSearchLabel.Text = "Search:";
            this.lblCopiesSearchLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCopiesSearchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));

            // 
            // txtCopiesSearch
            // 
            this.txtCopiesSearch.Location = new System.Drawing.Point(90, 46);
            this.txtCopiesSearch.Name = "txtCopiesSearch";
            this.txtCopiesSearch.Size = new System.Drawing.Size(250, 23);
            this.txtCopiesSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // 
            // btnCopiesRefresh
            // 
            this.btnCopiesRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCopiesRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiesRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCopiesRefresh.ForeColor = System.Drawing.Color.White;
            this.btnCopiesRefresh.Location = new System.Drawing.Point(545, 45);
            this.btnCopiesRefresh.Name = "btnCopiesRefresh";
            this.btnCopiesRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnCopiesRefresh.Text = "Refresh";
            this.btnCopiesRefresh.Click += new System.EventHandler(this.btnCopiesRefresh_Click);

            // 
            // btnCopiesAdd
            // 
            this.btnCopiesAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnCopiesAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiesAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCopiesAdd.ForeColor = System.Drawing.Color.White;
            this.btnCopiesAdd.Location = new System.Drawing.Point(665, 45);
            this.btnCopiesAdd.Name = "btnCopiesAdd";
            this.btnCopiesAdd.Size = new System.Drawing.Size(110, 30);
            this.btnCopiesAdd.Text = "Add Copy";
            this.btnCopiesAdd.Click += new System.EventHandler(this.btnCopiesAdd_Click);

            // 
            // dgvCopies
            // 
            this.dgvCopies.AllowUserToAddRows = false;
            this.dgvCopies.AllowUserToDeleteRows = false;
            this.dgvCopies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCopies.BackgroundColor = System.Drawing.Color.White;
            this.dgvCopies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCopies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCopies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCopies.EnableHeadersVisualStyles = false;
            this.dgvCopies.Location = new System.Drawing.Point(25, 90);
            this.dgvCopies.Name = "dgvCopies";
            this.dgvCopies.ReadOnly = true;
            this.dgvCopies.RowHeadersVisible = false;
            this.dgvCopies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCopies.Size = new System.Drawing.Size(750, 345);
            this.dgvCopies.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvCopies.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvCopies.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvCopies.ColumnHeadersHeight = 35;
            this.dgvCopies.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvCopies.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.dgvCopies.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Controls.Add(this.pnlPageNumbers);
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Controls.Add(this.lblPageInfo);
            this.pnlPagination.Controls.Add(this.lblTotalCount);
            this.pnlPagination.Location = new System.Drawing.Point(25, 455);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(750, 45);

            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnPrev.Location = new System.Drawing.Point(0, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 25);
            this.btnPrev.Text = "◀";
            this.btnPrev.UseVisualStyleBackColor = false;

            // 
            // pnlPageNumbers
            // 
            this.pnlPageNumbers.Location = new System.Drawing.Point(45, 5);
            this.pnlPageNumbers.Name = "pnlPageNumbers";
            this.pnlPageNumbers.Size = new System.Drawing.Size(300, 25);

            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnNext.Location = new System.Drawing.Point(355, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 25);
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = false;

            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPageInfo.Location = new System.Drawing.Point(410, 8);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(120, 20);
            this.lblPageInfo.Text = "Page 1 of 1";

            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTotalCount.Location = new System.Drawing.Point(540, 8);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(210, 20);
            this.lblTotalCount.Text = "Total: 0 records";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // 
            // UcCopy
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.lblCopiesViewHeader);
            this.Controls.Add(this.dgvCopies);
            this.Controls.Add(this.btnCopiesRefresh);
            this.Controls.Add(this.btnCopiesAdd);
            this.Controls.Add(this.lblCopiesSearchLabel);
            this.Controls.Add(this.txtCopiesSearch);
            this.Controls.Add(this.pnlPagination);
            this.Name = "UcCopy";
            this.Size = new System.Drawing.Size(804, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCopies)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
