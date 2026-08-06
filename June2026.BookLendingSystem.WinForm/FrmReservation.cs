using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using June2026.BookLendingSystem.ConsoleApp.Features.Reservations;

namespace June2026.BookLendingSystem.WinForm
{
    public partial class FrmReservation : Form
    {
        private readonly ReservationHttpClientService _resService;

        public FrmReservation()
        {
            InitializeComponent();
            _resService = new ReservationHttpClientService();
        }

        private async void FrmReservation_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var list = await _resService.ReadAsync();
            dgvReservations.DataSource = null;
            dgvReservations.DataSource = list;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBookId.Text, out int bookId) || string.IsNullOrWhiteSpace(txtMemberId.Text))
            {
                MessageBox.Show("Please enter a valid numeric Book ID and Member ID.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = new ReservationViewModel
            {
                BookId = bookId,
                MemberId = txtMemberId.Text.Trim(),
                ReservedAt = DateTime.Now,
                Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Pending" : txtStatus.Text.Trim()
            };

            bool success = await _resService.CreateAsync(res);
            MessageBox.Show(success ? "Reservation created successfully via HttpClient!" : "Failed to create reservation.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtResId.Text, out int resId) || !int.TryParse(txtBookId.Text, out int bookId))
            {
                MessageBox.Show("Please select a reservation to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var res = new ReservationViewModel
            {
                ReservationId = resId,
                BookId = bookId,
                MemberId = txtMemberId.Text.Trim(),
                Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Pending" : txtStatus.Text.Trim()
            };

            bool success = await _resService.UpdateAsync(res);
            MessageBox.Show(success ? "Reservation updated successfully via HttpClient!" : "Failed to update reservation.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            await LoadDataAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtResId.Text, out int resId))
            {
                MessageBox.Show("Please select a reservation from the list to delete.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete Reservation ID #{resId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool success = await _resService.DeleteAsync(resId);
                MessageBox.Show(success ? "Reservation deleted successfully via HttpClient!" : "Failed to delete reservation.", "Book Lending System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await LoadDataAsync();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtResId.Text = "";
            txtBookId.Text = "";
            txtMemberId.Text = "";
            txtStatus.Text = "Pending";
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservations.Rows[e.RowIndex].DataBoundItem is ReservationViewModel r)
            {
                txtResId.Text = r.ReservationId.ToString();
                txtBookId.Text = r.BookId.ToString();
                txtMemberId.Text = r.MemberId;
                txtStatus.Text = r.Status;
            }
        }
    }
}
