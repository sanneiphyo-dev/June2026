using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Members;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class UcMember : UserControl
    {
        private List<MemberViewModel> _allMembers = new List<MemberViewModel>();
        private readonly MemberHttpClientService _memberService = new MemberHttpClientService();

        private int _currentPage = 1;
        private const int _pageSize = 10;
        private int _totalPages = 1;

        public UcMember()
        {
            InitializeComponent();
            txtMembersSearch.TextChanged += txtMembersSearch_TextChanged;
            dgvMembers.CellClick += dgvMembers_CellClick;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
        }

        public async Task LoadMembersDataAsync()
        {
            _allMembers = await _memberService.ReadAsync();
            _currentPage = 1; // Reset to page 1 on fresh load
            FilterMembersLocal();
        }

        private void FilterMembersLocal()
        {
            string keyword = txtMembersSearch.Text.Trim();
            var filtered = _allMembers;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = _allMembers.Where(m =>
                    (m.FullName != null && m.FullName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (m.MemberId != null && m.MemberId.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            int totalRecords = filtered.Count;
            _totalPages = (int)Math.Ceiling((double)totalRecords / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = 1;

            var pageData = filtered.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            dgvMembers.DataSource = null;
            dgvMembers.DataSource = pageData;

            if (dgvMembers.Columns["MemberId"] != null)
            {
                dgvMembers.Columns["MemberId"].HeaderText = "Member ID";
            }
            if (dgvMembers.Columns["FullName"] != null)
            {
                dgvMembers.Columns["FullName"].HeaderText = "Full Name";
            }
            if (dgvMembers.Columns["Email"] != null)
            {
                dgvMembers.Columns["Email"].HeaderText = "Email";
            }
            if (dgvMembers.Columns["Phone"] != null)
            {
                dgvMembers.Columns["Phone"].HeaderText = "Phone";
            }
            if (dgvMembers.Columns["Role"] != null)
            {
                dgvMembers.Columns["Role"].HeaderText = "Role";
            }
            if (dgvMembers.Columns["Status"] != null)
            {
                dgvMembers.Columns["Status"].HeaderText = "Status";
            }

            GridHelper.EnsureSrColumn(dgvMembers, _currentPage, _pageSize);
            EnsureGridActionColumns(dgvMembers);

            // Update Pagination UI
            lblPageInfo.Text = $"Page {_currentPage} of {_totalPages}";
            lblTotalCount.Text = $"Total: {totalRecords} records";
            btnPrev.Enabled = (_currentPage > 1);
            btnNext.Enabled = (_currentPage < _totalPages);

            pnlPageNumbers.Controls.Clear();
            for (int i = 1; i <= _totalPages; i++)
            {
                var pageBtn = new Button
                {
                    Text = i.ToString(),
                    Width = 35,
                    Height = 25,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = (i == _currentPage) ? System.Drawing.Color.FromArgb(37, 99, 235) : System.Drawing.Color.White,
                    ForeColor = (i == _currentPage) ? System.Drawing.Color.White : System.Drawing.Color.Black,
                    Tag = i
                };
                pageBtn.FlatAppearance.BorderSize = 1;
                pageBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
                pageBtn.Click += PageBtn_Click;
                pnlPageNumbers.Controls.Add(pageBtn);
            }
        }

        private void PageBtn_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int pageNum)
            {
                _currentPage = pageNum;
                FilterMembersLocal();
            }
        }

        private void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                FilterMembersLocal();
            }
        }

        private void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                FilterMembersLocal();
            }
        }

        private void txtMembersSearch_TextChanged(object? sender, EventArgs e)
        {
            _currentPage = 1; // Reset to page 1 on search key change
            FilterMembersLocal();
        }

        private void EnsureGridActionColumns(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("ActionCol"))
            {
                var actionCol = new DataGridViewTextBoxColumn
                {
                    Name = "ActionCol",
                    HeaderText = "Actions",
                    Width = 80,
                    ReadOnly = true
                };
                actionCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                actionCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns.Add(actionCol);
            }

            // Force display index to the end
            dgv.Columns["ActionCol"].DisplayIndex = dgv.Columns.Count - 1;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Cells["ActionCol"].Value = "✏️   🗑️";
            }
        }

        private async void btnMembersRefresh_Click(object sender, EventArgs e)
        {
            await LoadMembersDataAsync();
        }

        private async void btnMembersAdd_Click(object sender, EventArgs e)
        {
            string newId = $"MEM-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
            using (var dialog = new FrmMemberDialog("Add Member Profile", newId))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(dialog.MemberId) || string.IsNullOrWhiteSpace(dialog.FullName) || string.IsNullOrWhiteSpace(dialog.Email))
                    {
                        MessageBox.Show("Member ID, Full Name and Email are required.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var member = new MemberViewModel
                    {
                        MemberId = dialog.MemberId,
                        FullName = dialog.FullName,
                        Email = dialog.Email,
                        Phone = string.IsNullOrWhiteSpace(dialog.Phone) ? null : dialog.Phone,
                        Role = string.IsNullOrWhiteSpace(dialog.Role) ? "Student" : dialog.Role,
                        Status = string.IsNullOrWhiteSpace(dialog.Status) ? "Active" : dialog.Status
                    };

                    try
                    {
                        bool success = await _memberService.CreateAsync(member);
                        MessageBox.Show(success ? "Member created successfully!" : "Failed to create member.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    await LoadMembersDataAsync();
                }
            }
        }

        private async void dgvMembers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender!;
            if (dgv.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                var member = (MemberViewModel)dgv.Rows[e.RowIndex].DataBoundItem;
                var cellBounds = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var relativeX = dgv.PointToClient(Cursor.Position).X - cellBounds.Left;

                if (relativeX < cellBounds.Width / 2)
                {
                    // Edit (✏️)
                    using (var dialog = new FrmMemberDialog("Edit Member Settings", member.MemberId, member.FullName, member.Email, member.Phone ?? "", member.Role, member.Status))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (string.IsNullOrWhiteSpace(dialog.FullName) || string.IsNullOrWhiteSpace(dialog.Email))
                            {
                                MessageBox.Show("Full Name and Email are required.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            member.FullName = dialog.FullName;
                            member.Email = dialog.Email;
                            member.Phone = string.IsNullOrWhiteSpace(dialog.Phone) ? null : dialog.Phone;
                            member.Role = string.IsNullOrWhiteSpace(dialog.Role) ? "Student" : dialog.Role;
                            member.Status = string.IsNullOrWhiteSpace(dialog.Status) ? "Active" : dialog.Status;

                            try
                            {
                                bool success = await _memberService.UpdateAsync(member);
                                MessageBox.Show(success ? "Member updated successfully!" : "Failed to update member.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to update member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            await LoadMembersDataAsync();
                        }
                    }
                }
                else
                {
                    // Delete (❌)
                    var confirm = MessageBox.Show($"Are you sure you want to soft delete member '{member.FullName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        bool success = await _memberService.DeleteAsync(member.MemberId);
                        MessageBox.Show(success ? "Member deleted successfully!" : "Failed to delete member.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadMembersDataAsync();
                    }
                }
            }
        }
    }
}
