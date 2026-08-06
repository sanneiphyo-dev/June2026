using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BookCopies
{
    public static class BookCopyUI
    {
        private static readonly BookCopyService _service = new BookCopyService();

        public static void Run()
        {
            Console.WriteLine("\n--- BOOK COPIES MANAGEMENT ---");
            Console.WriteLine("1. Add Book Copy");
            Console.WriteLine("2. View All Book Copies");
            Console.WriteLine("3. Find Copy by ID");
            Console.WriteLine("4. Update Copy");
            Console.WriteLine("5. Delete Copy");
            Console.Write("Select: ");

            switch (Console.ReadLine())
            {
                case "1": AddCopy(); break;
                case "2": ViewCopies(); break;
                case "3": FindCopy(); break;
                case "4": UpdateCopy(); break;
                case "5": DeleteCopy(); break;
            }
        }

        private static void AddCopy()
        {
            Console.Write("Copy ID (e.g. CC-COPY-01): ");
            string copyId = Console.ReadLine() ?? "";
            Console.Write("Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.Write("Book Copy Count/Label: ");
                string count = Console.ReadLine() ?? "1";

                _service.Create(new BookCopyViewModel
                {
                    CopyId = copyId,
                    BookId = bookId,
                    BookCopyCount = count
                });
            }
        }

        private static void ViewCopies()
        {
            var copies = _service.Read();
            foreach (var c in copies)
            {
                Console.WriteLine(c.DisplayText);
            }
        }

        private static void FindCopy()
        {
            Console.Write("Copy ID: ");
            string id = Console.ReadLine() ?? "";
            var c = _service.GetById(id);
            if (c != null)
                Console.WriteLine(c.DisplayText);
            else
                Console.WriteLine("Copy not found.");
        }

        private static void UpdateCopy()
        {
            Console.Write("Copy ID to Update: ");
            string id = Console.ReadLine() ?? "";
            var c = _service.GetById(id);
            if (c != null)
            {
                Console.Write($"New Book ID ({c.BookId}): ");
                if (int.TryParse(Console.ReadLine(), out int bId)) c.BookId = bId;

                Console.Write($"New Copy Count ({c.BookCopyCount}): ");
                string count = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(count)) c.BookCopyCount = count;

                _service.Update(c);
            }
            else Console.WriteLine("Copy not found.");
        }

        private static void DeleteCopy()
        {
            Console.Write("Copy ID to Delete: ");
            string id = Console.ReadLine() ?? "";
            _service.Delete(id);
        }
    }
}
