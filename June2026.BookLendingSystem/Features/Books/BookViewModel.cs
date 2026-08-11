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

        [Browsable(false)]
        public string DisplayText => $"Book Title: {Title} | Author: {Author}  | Category: {Category ?? "N/A"}";
    }
}
