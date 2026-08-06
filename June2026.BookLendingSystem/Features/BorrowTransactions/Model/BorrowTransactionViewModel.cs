using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions.Model
{
    public class BorrowTransactionViewModel
    {
        public string TransactionId { get; set; } = string.Empty;
        public string MemberId { get; set; } = string.Empty;
        public string CopyId { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(14);
        public DateTime? ReturnDate { get; set; }
        public decimal FineAmount { get; set; } = 0.00m;
        public string Status { get; set; } = "Borrowed";
        public string? MemberName { get; set; }
        public string? BookTitle { get; set; }

        public string FormattedReturnDate => ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not Returned";
        public string DisplayText => $"[Txn ID: {TransactionId}] Member: {MemberId} ({MemberName ?? "N/A"}) | Copy ID: {CopyId} | Due: {DueDate:yyyy-MM-dd} | Return: {FormattedReturnDate} | Fine: ${FineAmount} | Status: {Status}";
    }
}
