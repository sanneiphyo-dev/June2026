using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Reservations;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class UcReservation : UserControl
    {
        private List<ReservationViewModel> _allReservations = new List<ReservationViewModel>();
        private readonly ReservationHttpClientService _resService = new ReservationHttpClientService();

        private int _currentPage = 1;
        private const int _pageSize = 10;
        private int _totalPages = 1;

        public UcReservation()
        {
            InitializeComponent();
            txtResSearch.TextChanged += txtResSearch_TextChanged;
            dgvReservations.CellClick += dgvReservations_CellClick;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
        }

        public async Task LoadReservationsDataAsync()
        {
            _allReservations = await _resService.ReadAsync();
            _currentPage = 1; // Reset to page 1 on fresh load
            FilterReservationsLocal();
        }

        private void FilterReservationsLocal()
        {
            string keyword = txtResSearch.Text.Trim();
            var filtered = _allReservations;
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = _allReservations.Where(r =>
                    (r.MemberId != null && r.MemberId.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (r.MemberName != null && r.MemberName.StartsWith(keyword, StringComparison.OrdinalIgnoreCase)) ||
                    (r.BookTitle != null && r.BookTitle.StartsWith(keyword, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            int totalRecords = filtered.Count;
            _totalPages = (int)Math.Ceiling((double)totalRecords / _pageSize);
            if (_totalPages < 1) _totalPages = 1;
            if (_currentPage > _totalPages) _currentPage = 1;

            var pageData = filtered.Skip((_currentPage - 1) * _pageSize).Take(_pageSize).ToList();

            dgvReservations.DataSource = null;
            dgvReservations.DataSource = pageData;

            if (dgvReservations.Columns["BookTitle"] != null)
            {
                dgvReservations.Columns["BookTitle"].HeaderText = "Book Title";
            }
            if (dgvReservations.Columns["MemberName"] != null)
            {
                dgvReservations.Columns["MemberName"].HeaderText = "Member Name";
            }
            if (dgvReservations.Columns["Status"] != null)
            {
                dgvReservations.Columns["Status"].HeaderText = "Status";
            }

            GridHelper.EnsureSrColumn(dgvReservations, _currentPage, _pageSize);
            EnsureGridActionColumns(dgvReservations);

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
                FilterReservationsLocal();
            }
        }

        private void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                FilterReservationsLocal();
            }
        }

        private void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                FilterReservationsLocal();
            }
        }

        private void txtResSearch_TextChanged(object? sender, EventArgs e)
        {
            _currentPage = 1; // Reset to page 1 on search key change
            FilterReservationsLocal();
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

        private async void btnResRefresh_Click(object sender, EventArgs e)
        {
            await LoadReservationsDataAsync();
        }

        private async void btnResAdd_Click(object sender, EventArgs e)
        {
            using (var dialog = new FrmReservationDialog("Place Book Hold"))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!int.TryParse(dialog.BookId, out int bookId) || string.IsNullOrWhiteSpace(dialog.MemberId))
                    {
                        MessageBox.Show("Book ID (numeric) and Member ID are required.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var res = new ReservationViewModel
                    {
                        BookId = bookId,
                        MemberId = dialog.MemberId,
                        Status = dialog.Status
                    };

                    await _resService.CreateAsync(res);
                    MessageBox.Show("Reservation holds placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadReservationsDataAsync();
                }
            }
        }

        private async void dgvReservations_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender!;
            if (dgv.Columns[e.ColumnIndex].Name == "ActionCol")
            {
                var resVal = (ReservationViewModel)dgv.Rows[e.RowIndex].DataBoundItem;
                var cellBounds = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var relativeX = dgv.PointToClient(Cursor.Position).X - cellBounds.Left;

                if (relativeX < cellBounds.Width / 2)
                {
                    // Edit (✏️)
                    using (var dialog = new FrmReservationDialog("Edit Reservation Settings", resVal.BookId.ToString(), resVal.MemberId, resVal.Status))
                    {
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            if (!int.TryParse(dialog.BookId, out int bookId) || string.IsNullOrWhiteSpace(dialog.MemberId))
                            {
                                MessageBox.Show("Book ID (numeric) and Member ID are required.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            resVal.BookId = bookId;
                            resVal.MemberId = dialog.MemberId;
                            resVal.Status = dialog.Status;

                            await _resService.UpdateAsync(resVal);
                            MessageBox.Show("Reservation updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadReservationsDataAsync();
                        }
                    }
                }
                else
                {
                    // Delete (❌)
                    var confirm = MessageBox.Show($"Are you sure you want to soft delete reservation hold #{resVal.ReservationId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        bool success = await _resService.DeleteAsync(resVal.ReservationId);
                        MessageBox.Show(success ? "Reservation deleted successfully!" : "Failed to delete reservation.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadReservationsDataAsync();
                    }
                }
            }
        }
    }
}
