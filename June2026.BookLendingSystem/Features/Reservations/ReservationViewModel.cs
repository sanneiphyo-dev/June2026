using System;
using System.ComponentModel;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Reservations
{
    public class ReservationViewModel
    {
        [Browsable(false)]
        public int ReservationId { get; set; }

        [Browsable(false)]
        public int BookId { get; set; }

        [Browsable(false)]
        public string MemberId { get; set; } = string.Empty;

        public string? BookTitle { get; set; }
        public string? MemberName { get; set; }

        public string Status { get; set; } 

        [Browsable(false)]
        public string DisplayText => $"Book Title: {BookTitle ?? "N/A"} | Member: {MemberName ?? "N/A"} | Status: {Status}";
    }
}
