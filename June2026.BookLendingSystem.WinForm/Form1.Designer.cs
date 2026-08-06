namespace June2026.BookLendingSystem.WinForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TabPage tabCopies;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.TabPage tabTransactions;
        private System.Windows.Forms.TabPage tabReservations;

        // Books Tab Controls
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.TextBox txtBookAuthor;
        private System.Windows.Forms.TextBox txtBookPublisher;
        private System.Windows.Forms.TextBox txtBookCategory;
        private System.Windows.Forms.TextBox txtBookId;
        private System.Windows.Forms.Button btnBookLoad;
        private System.Windows.Forms.Button btnBookAdd;
        private System.Windows.Forms.Button btnBookUpdate;
        private System.Windows.Forms.Button btnBookDelete;

        // Members Tab Controls
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.TextBox txtMemberId;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.TextBox txtMemberEmail;
        private System.Windows.Forms.TextBox txtMemberPhone;
        private System.Windows.Forms.TextBox txtMemberRole;
        private System.Windows.Forms.TextBox txtMemberStatus;
        private System.Windows.Forms.Button btnMemberLoad;
        private System.Windows.Forms.Button btnMemberAdd;
        private System.Windows.Forms.Button btnMemberUpdate;
        private System.Windows.Forms.Button btnMemberDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.tabCopies = new System.Windows.Forms.TabPage();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.tabTransactions = new System.Windows.Forms.TabPage();
            this.tabReservations = new System.Windows.Forms.TabPage();

            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.txtBookId = new System.Windows.Forms.TextBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.txtBookAuthor = new System.Windows.Forms.TextBox();
            this.txtBookPublisher = new System.Windows.Forms.TextBox();
            this.txtBookCategory = new System.Windows.Forms.TextBox();
            this.btnBookLoad = new System.Windows.Forms.Button();
            this.btnBookAdd = new System.Windows.Forms.Button();
            this.btnBookUpdate = new System.Windows.Forms.Button();
            this.btnBookDelete = new System.Windows.Forms.Button();

            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.txtMemberId = new System.Windows.Forms.TextBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.txtMemberEmail = new System.Windows.Forms.TextBox();
            this.txtMemberPhone = new System.Windows.Forms.TextBox();
            this.txtMemberRole = new System.Windows.Forms.TextBox();
            this.txtMemberStatus = new System.Windows.Forms.TextBox();
            this.btnMemberLoad = new System.Windows.Forms.Button();
            this.btnMemberAdd = new System.Windows.Forms.Button();
            this.btnMemberUpdate = new System.Windows.Forms.Button();
            this.btnMemberDelete = new System.Windows.Forms.Button();

            this.tabMain.SuspendLayout();
            this.tabBooks.SuspendLayout();
            this.tabMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.SuspendLayout();

            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabBooks);
            this.tabMain.Controls.Add(this.tabCopies);
            this.tabMain.Controls.Add(this.tabMembers);
            this.tabMain.Controls.Add(this.tabTransactions);
            this.tabMain.Controls.Add(this.tabReservations);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(950, 550);

            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Controls.Add(this.txtBookId);
            this.tabBooks.Controls.Add(this.txtBookTitle);
            this.tabBooks.Controls.Add(this.txtBookAuthor);
            this.tabBooks.Controls.Add(this.txtBookPublisher);
            this.tabBooks.Controls.Add(this.txtBookCategory);
            this.tabBooks.Controls.Add(this.btnBookLoad);
            this.tabBooks.Controls.Add(this.btnBookAdd);
            this.tabBooks.Controls.Add(this.btnBookUpdate);
            this.tabBooks.Controls.Add(this.btnBookDelete);
            this.tabBooks.Text = "Books Management";

            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(20, 20);
            this.dgvBooks.Size = new System.Drawing.Size(550, 450);

            // 
            // Inputs & Buttons positioning for Books
            // 
            this.txtBookId.Location = new System.Drawing.Point(600, 30);
            this.txtBookId.PlaceholderText = "Book ID (for Update/Delete)";
            this.txtBookId.Size = new System.Drawing.Size(300, 25);

            this.txtBookTitle.Location = new System.Drawing.Point(600, 70);
            this.txtBookTitle.PlaceholderText = "Book Title";
            this.txtBookTitle.Size = new System.Drawing.Size(300, 25);

            this.txtBookAuthor.Location = new System.Drawing.Point(600, 110);
            this.txtBookAuthor.PlaceholderText = "Author";
            this.txtBookAuthor.Size = new System.Drawing.Size(300, 25);

            this.txtBookPublisher.Location = new System.Drawing.Point(600, 150);
            this.txtBookPublisher.PlaceholderText = "Publisher";
            this.txtBookPublisher.Size = new System.Drawing.Size(300, 25);

            this.txtBookCategory.Location = new System.Drawing.Point(600, 190);
            this.txtBookCategory.PlaceholderText = "Category";
            this.txtBookCategory.Size = new System.Drawing.Size(300, 25);

            this.btnBookLoad.Location = new System.Drawing.Point(600, 240);
            this.btnBookLoad.Size = new System.Drawing.Size(140, 35);
            this.btnBookLoad.Text = "Load Books (HTTP)";
            this.btnBookLoad.Click += new System.EventHandler(this.btnBookLoad_Click);

            this.btnBookAdd.Location = new System.Drawing.Point(760, 240);
            this.btnBookAdd.Size = new System.Drawing.Size(140, 35);
            this.btnBookAdd.Text = "Add Book";
            this.btnBookAdd.Click += new System.EventHandler(this.btnBookAdd_Click);

            this.btnBookUpdate.Location = new System.Drawing.Point(600, 290);
            this.btnBookUpdate.Size = new System.Drawing.Size(140, 35);
            this.btnBookUpdate.Text = "Update Book";
            this.btnBookUpdate.Click += new System.EventHandler(this.btnBookUpdate_Click);

            this.btnBookDelete.Location = new System.Drawing.Point(760, 290);
            this.btnBookDelete.Size = new System.Drawing.Size(140, 35);
            this.btnBookDelete.Text = "Delete Book";
            this.btnBookDelete.Click += new System.EventHandler(this.btnBookDelete_Click);

            // 
            // tabMembers
            // 
            this.tabMembers.Controls.Add(this.dgvMembers);
            this.tabMembers.Controls.Add(this.txtMemberId);
            this.tabMembers.Controls.Add(this.txtMemberName);
            this.tabMembers.Controls.Add(this.txtMemberEmail);
            this.tabMembers.Controls.Add(this.txtMemberPhone);
            this.tabMembers.Controls.Add(this.txtMemberRole);
            this.tabMembers.Controls.Add(this.txtMemberStatus);
            this.tabMembers.Controls.Add(this.btnMemberLoad);
            this.tabMembers.Controls.Add(this.btnMemberAdd);
            this.tabMembers.Controls.Add(this.btnMemberUpdate);
            this.tabMembers.Controls.Add(this.btnMemberDelete);
            this.tabMembers.Text = "Members Management";

            // 
            // dgvMembers
            // 
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembers.Location = new System.Drawing.Point(20, 20);
            this.dgvMembers.Size = new System.Drawing.Size(550, 450);

            this.txtMemberId.Location = new System.Drawing.Point(600, 30);
            this.txtMemberId.PlaceholderText = "Member ID (e.g. MEM-1082)";
            this.txtMemberId.Size = new System.Drawing.Size(300, 25);

            this.txtMemberName.Location = new System.Drawing.Point(600, 70);
            this.txtMemberName.PlaceholderText = "Full Name";
            this.txtMemberName.Size = new System.Drawing.Size(300, 25);

            this.txtMemberEmail.Location = new System.Drawing.Point(600, 110);
            this.txtMemberEmail.PlaceholderText = "Email";
            this.txtMemberEmail.Size = new System.Drawing.Size(300, 25);

            this.txtMemberPhone.Location = new System.Drawing.Point(600, 150);
            this.txtMemberPhone.PlaceholderText = "Phone";
            this.txtMemberPhone.Size = new System.Drawing.Size(300, 25);

            this.txtMemberRole.Location = new System.Drawing.Point(600, 190);
            this.txtMemberRole.PlaceholderText = "Role (Student/Teacher)";
            this.txtMemberRole.Size = new System.Drawing.Size(300, 25);

            this.txtMemberStatus.Location = new System.Drawing.Point(600, 230);
            this.txtMemberStatus.PlaceholderText = "Status (Active/Inactive)";
            this.txtMemberStatus.Size = new System.Drawing.Size(300, 25);

            this.btnMemberLoad.Location = new System.Drawing.Point(600, 280);
            this.btnMemberLoad.Size = new System.Drawing.Size(140, 35);
            this.btnMemberLoad.Text = "Load Members";
            this.btnMemberLoad.Click += new System.EventHandler(this.btnMemberLoad_Click);

            this.btnMemberAdd.Location = new System.Drawing.Point(760, 280);
            this.btnMemberAdd.Size = new System.Drawing.Size(140, 35);
            this.btnMemberAdd.Text = "Add Member";
            this.btnMemberAdd.Click += new System.EventHandler(this.btnMemberAdd_Click);

            this.btnMemberUpdate.Location = new System.Drawing.Point(600, 330);
            this.btnMemberUpdate.Size = new System.Drawing.Size(140, 35);
            this.btnMemberUpdate.Text = "Update Member";
            this.btnMemberUpdate.Click += new System.EventHandler(this.btnMemberUpdate_Click);

            this.btnMemberDelete.Location = new System.Drawing.Point(760, 330);
            this.btnMemberDelete.Size = new System.Drawing.Size(140, 35);
            this.btnMemberDelete.Text = "Delete Member";
            this.btnMemberDelete.Click += new System.EventHandler(this.btnMemberDelete_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.tabMain);
            this.Name = "Form1";
            this.Text = "Book Lending System - Windows Forms (HttpClient UI)";
            this.tabMain.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            this.tabMembers.ResumeLayout(false);
            this.tabMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
