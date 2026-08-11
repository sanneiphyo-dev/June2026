namespace June2026.BookLendingSystem.WinForm
{
    partial class UcBook
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBooksViewHeader;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnBooksRefresh;
        private System.Windows.Forms.Button btnBooksAdd;
        private System.Windows.Forms.Label lblBooksSearchLabel;
        private System.Windows.Forms.TextBox txtBooksSearch;

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
            this.lblBooksViewHeader = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnBooksRefresh = new System.Windows.Forms.Button();
            this.btnBooksAdd = new System.Windows.Forms.Button();
            this.lblBooksSearchLabel = new System.Windows.Forms.Label();
            this.txtBooksSearch = new System.Windows.Forms.TextBox();

            // Pagination Initialization
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlPageNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblBooksViewHeader
            // 
            this.lblBooksViewHeader.AutoSize = true;
            this.lblBooksViewHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblBooksViewHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBooksViewHeader.Location = new System.Drawing.Point(25, 15);
            this.lblBooksViewHeader.Name = "lblBooksViewHeader";
            this.lblBooksViewHeader.Size = new System.Drawing.Size(251, 17);
            this.lblBooksViewHeader.Text = "Register new titles to the central catalog.";

            // 
            // lblBooksSearchLabel
            // 
            this.lblBooksSearchLabel.Location = new System.Drawing.Point(25, 50);
            this.lblBooksSearchLabel.Name = "lblBooksSearchLabel";
            this.lblBooksSearchLabel.Size = new System.Drawing.Size(60, 20);
            this.lblBooksSearchLabel.Text = "Search:";
            this.lblBooksSearchLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBooksSearchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));

            // 
            // txtBooksSearch
            // 
            this.txtBooksSearch.Location = new System.Drawing.Point(90, 46);
            this.txtBooksSearch.Name = "txtBooksSearch";
            this.txtBooksSearch.Size = new System.Drawing.Size(250, 23);
            this.txtBooksSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            // 
            // btnBooksRefresh
            // 
            this.btnBooksRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnBooksRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooksRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBooksRefresh.ForeColor = System.Drawing.Color.White;
            this.btnBooksRefresh.Location = new System.Drawing.Point(545, 45);
            this.btnBooksRefresh.Name = "btnBooksRefresh";
            this.btnBooksRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnBooksRefresh.Text = "Refresh";
            this.btnBooksRefresh.Click += new System.EventHandler(this.btnBooksRefresh_Click);

            // 
            // btnBooksAdd
            // 
            this.btnBooksAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnBooksAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooksAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBooksAdd.ForeColor = System.Drawing.Color.White;
            this.btnBooksAdd.Location = new System.Drawing.Point(665, 45);
            this.btnBooksAdd.Name = "btnBooksAdd";
            this.btnBooksAdd.Size = new System.Drawing.Size(110, 30);
            this.btnBooksAdd.Text = "Add Book";
            this.btnBooksAdd.Click += new System.EventHandler(this.btnBooksAdd_Click);

            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.Location = new System.Drawing.Point(25, 90);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(750, 345);
            this.dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.dgvBooks.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvBooks.ColumnHeadersHeight = 35;
            this.dgvBooks.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.dgvBooks.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.dgvBooks.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);

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
            // UcBook
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.lblBooksViewHeader);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.btnBooksRefresh);
            this.Controls.Add(this.btnBooksAdd);
            this.Controls.Add(this.lblBooksSearchLabel);
            this.Controls.Add(this.txtBooksSearch);
            this.Controls.Add(this.pnlPagination);
            this.Name = "UcBook";
            this.Size = new System.Drawing.Size(804, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.pnlPagination.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
