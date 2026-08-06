using System;
using System.ComponentModel;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Books
{
    public class BookViewModel
    {
        [Browsable(false)]
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Browsable(false)]
        public string DisplayText => $"Title: {Title} | Author: {Author} | Publisher: {Publisher ?? "N/A"} | Category: {Category ?? "N/A"}";
    }
}
