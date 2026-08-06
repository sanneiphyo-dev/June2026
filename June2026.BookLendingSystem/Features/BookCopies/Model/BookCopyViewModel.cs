namespace June2026.BookLendingSystem.ConsoleApp.Features.BookCopies.Model
{
    public class BookCopyViewModel
    {
        public string CopyId { get; set; } = string.Empty;
        public int BookId { get; set; }
        public string BookCopyCount { get; set; } = string.Empty;
        public string? BookTitle { get; set; }

        public string DisplayText => $"[Copy ID: {CopyId}] Book ID: {BookId} ({BookTitle ?? "N/A"}) | Count: {BookCopyCount}";
    }
}
