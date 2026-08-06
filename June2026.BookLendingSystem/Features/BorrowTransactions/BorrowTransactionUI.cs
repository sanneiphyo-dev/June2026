using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions
{
    public static class BorrowTransactionUI
    {
        private static readonly BorrowTransactionService _service = new BorrowTransactionService();

        public static void Run()
        {
            Console.WriteLine("\n--- BORROW TRANSACTIONS MANAGEMENT ---");
            Console.WriteLine("1. Borrow Book (New Transaction)");
            Console.WriteLine("2. View All Transactions");
            Console.WriteLine("3. Find Transaction by ID");
            Console.WriteLine("4. Update / Return Book");
            Console.WriteLine("5. Delete Transaction");
            Console.Write("Select: ");

            switch (Console.ReadLine())
            {
                case "1": AddTxn(); break;
                case "2": ViewTxns(); break;
                case "3": FindTxn(); break;
                case "4": UpdateTxn(); break;
                case "5": DeleteTxn(); break;
            }
        }

        private static void AddTxn()
        {
            Console.Write("Transaction ID (e.g. TXN-2026-0089): ");
            string txnId = Console.ReadLine() ?? "";
            Console.Write("Member ID: ");
            string memId = Console.ReadLine() ?? "";
            Console.Write("Copy ID: ");
            string copyId = Console.ReadLine() ?? "";
            Console.Write("Due Date (days from today, default 14): ");
            string daysStr = Console.ReadLine() ?? "";
            int days = int.TryParse(daysStr, out int d) ? d : 14;

            _service.Create(new BorrowTransactionViewModel
            {
                TransactionId = txnId,
                MemberId = memId,
                CopyId = copyId,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(days),
                Status = "Borrowed",
                FineAmount = 0.00m
            });
        }

        private static void ViewTxns()
        {
            var txns = _service.Read();
            foreach (var t in txns)
            {
                Console.WriteLine(t.DisplayText);
            }
        }

        private static void FindTxn()
        {
            Console.Write("Transaction ID: ");
            string id = Console.ReadLine() ?? "";
            var t = _service.GetById(id);
            if (t != null)
            {
                Console.WriteLine(t.DisplayText);
            }
            else Console.WriteLine("Transaction not found.");
        }

        private static void UpdateTxn()
        {
            Console.Write("Transaction ID to Update/Return: ");
            string id = Console.ReadLine() ?? "";
            var t = _service.GetById(id);
            if (t != null)
            {
                Console.WriteLine("Select Action: 1. Mark as Returned  2. Custom Update");
                string act = Console.ReadLine() ?? "";
                if (act == "1")
                {
                    t.ReturnDate = DateTime.Now;
                    t.Status = "Returned";
                    if (DateTime.Now > t.DueDate)
                    {
                        int overdueDays = (DateTime.Now - t.DueDate).Days;
                        t.FineAmount = overdueDays * 1.50m;
                        Console.WriteLine($"Book returned overdue by {overdueDays} day(s). Fine calculated: ${t.FineAmount}");
                    }
                }
                else
                {
                    Console.Write($"Status ({t.Status}): ");
                    string st = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(st)) t.Status = st;

                    Console.Write($"Fine Amount ({t.FineAmount}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal fine)) t.FineAmount = fine;
                }

                _service.Update(t);
            }
            else Console.WriteLine("Transaction not found.");
        }

        private static void DeleteTxn()
        {
            Console.Write("Transaction ID to Delete: ");
            string id = Console.ReadLine() ?? "";
            _service.Delete(id);
        }
    }
}
