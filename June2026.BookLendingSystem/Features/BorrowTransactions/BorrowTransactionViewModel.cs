using System;
using System.ComponentModel;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions
{
    public class BorrowTransactionViewModel
    {
        [Browsable(false)]
        public string TransactionId { get; set; } = string.Empty;

        public string MemberId { get; set; } = string.Empty;

        [Browsable(false)]
        public string CopyId { get; set; } = string.Empty;

        public string? MemberName { get; set; }

        public string? BookTitle { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);

        [Browsable(false)]
        public DateTime? ReturnDate { get; set; }

        [Browsable(false)]
        public decimal FineAmount { get; set; } = 0.00m;

        public string Status { get; set; } = "Borrowed";

        [Browsable(false)]
        public string DisplayText => $"Member Name: {MemberName ?? "N/A"} | Book: {BookTitle ?? "N/A"} |Fine: ${FineAmount} | Status: {Status}";
    }
}
