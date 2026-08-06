using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Books
{
    public class BookDataModel
    {
        public int book_id { get; set; }
        public string title { get; set; } = string.Empty;
        public string author { get; set; } = string.Empty;
        public string? publisher { get; set; }
        public string? category { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
    }
}
