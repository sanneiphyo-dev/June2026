using System;
using System.ComponentModel;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions
{
    public class BorrowTransactionViewModel
    {
        [Browsable(false)]
        public string TransactionId { get; set; } = string.Empty;

        [Browsable(false)]
        public string MemberId { get; set; } = string.Empty;

        [Browsable(false)]
        public string CopyId { get; set; } = string.Empty;

        public string? MemberName { get; set; }
        public string? BookTitle { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
        public DateTime? ReturnDate { get; set; }
        public decimal FineAmount { get; set; } = 0.00m;
        public string Status { get; set; } = "Borrowed";

        public string FormattedReturnDate => ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not Returned";

        [Browsable(false)]
        public string DisplayText => $"Member: {MemberName ?? "N/A"} | Book: {BookTitle ?? "N/A"} | Due: {DueDate:yyyy-MM-dd} | Return: {FormattedReturnDate} | Fine: ${FineAmount} | Status: {Status}";
    }
}
