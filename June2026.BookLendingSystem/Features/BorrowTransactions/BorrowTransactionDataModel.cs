using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions
{
    public class BorrowTransactionDataModel
    {
        public string transaction_id { get; set; } = string.Empty;
        public string member_id { get; set; } = string.Empty;
        public string copy_id { get; set; } = string.Empty;
        public DateTime borrow_date { get; set; } = DateTime.Now;
        public DateTime due_date { get; set; } = DateTime.Now;
        public DateTime? return_date { get; set; }
        public decimal fine_amount { get; set; } = 0.00m;
        public string status { get; set; } = string.Empty;
        public string? full_name { get; set; }
        public string? title { get; set; }
    }
}
