using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Reservations
{
    public class ReservationDataModel
    {
        public int reservation_id { get; set; }
        public int book_id { get; set; }
        public string member_id { get; set; } = string.Empty;
        public DateTime reserved_at { get; set; } = DateTime.Now;
        public string status { get; set; } = string.Empty;
        public string? title { get; set; }
        public string? full_name { get; set; }
    }
}
