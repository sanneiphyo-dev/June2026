using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Reservations.Model
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public int BookId { get; set; }
        public string MemberId { get; set; } = string.Empty;
        public DateTime ReservedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
        public string? BookTitle { get; set; }
        public string? MemberName { get; set; }

        public string DisplayText => $"[Reservation ID: {ReservationId}] Book ID: {BookId} ({BookTitle ?? "N/A"}) | Member ID: {MemberId} ({MemberName ?? "N/A"}) | Reserved At: {ReservedAt:yyyy-MM-dd HH:mm} | Status: {Status}";
    }
}
