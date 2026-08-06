using System.ComponentModel;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BookCopies
{
    public class BookCopyViewModel
    {
        [Browsable(false)]
        public string CopyId { get; set; } = string.Empty;

        [Browsable(false)]
        public int BookId { get; set; }

        public string? BookTitle { get; set; }
        public string BookCopyCount { get; set; } = string.Empty;

        [Browsable(false)]
        public string DisplayText => $"Book: {BookTitle ?? "N/A"} | Count: {BookCopyCount}";
    }
}
