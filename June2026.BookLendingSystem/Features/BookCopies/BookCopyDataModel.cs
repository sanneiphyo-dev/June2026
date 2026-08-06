namespace June2026.BookLendingSystem.ConsoleApp.Features.BookCopies
{
    public class BookCopyDataModel
    {
        public string copy_id { get; set; } = string.Empty;
        public int book_id { get; set; }
        public string book_copy_count { get; set; } = string.Empty;
        public string? title { get; set; }
    }
}
