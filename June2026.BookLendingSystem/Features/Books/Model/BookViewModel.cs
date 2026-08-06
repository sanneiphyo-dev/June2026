using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Books.Model
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string DisplayText => $"[ID: {BookId}] Title: {Title} | Author: {Author} | Publisher: {Publisher ?? "N/A"} | Category: {Category ?? "N/A"}";
    }
}
