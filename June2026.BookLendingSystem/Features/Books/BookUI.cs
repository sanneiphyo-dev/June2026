using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Books
{
    public static class BookUI
    {
        private static readonly BookService _service = new BookService();

        public static void Run()
        {
            Console.WriteLine("\n--- BOOK MANAGEMENT ---");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Find Book by ID");
            Console.WriteLine("4. Update Book");
            Console.WriteLine("5. Delete Book");
            Console.Write("Select: ");

            switch (Console.ReadLine())
            {
                case "1": AddBook(); break;
                case "2": ViewBooks(); break;
                case "3": FindBook(); break;
                case "4": UpdateBook(); break;
                case "5": DeleteBook(); break;
            }
        }

        private static void AddBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("Author: ");
            string author = Console.ReadLine() ?? "";
            Console.Write("Publisher: ");
            string? pub = Console.ReadLine();
            Console.Write("Category: ");
            string? cat = Console.ReadLine();

            _service.Create(new BookViewModel
            {
                Title = title,
                Author = author,
                Publisher = string.IsNullOrWhiteSpace(pub) ? null : pub,
                Category = string.IsNullOrWhiteSpace(cat) ? null : cat
            });
        }

        private static void ViewBooks()
        {
            var books = _service.Read();
            foreach (var b in books)
            {
                Console.WriteLine(b.DisplayText);
            }
        }

        private static void FindBook()
        {
            Console.Write("Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var b = _service.GetById(id);
                if (b != null)
                    Console.WriteLine(b.DisplayText);
                else
                    Console.WriteLine("Book not found.");
            }
        }

        private static void UpdateBook()
        {
            Console.Write("Book ID to Update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var b = _service.GetById(id);
                if (b != null)
                {
                    Console.Write($"New Title ({b.Title}): ");
                    string title = Console.ReadLine() ?? "";
                    Console.Write($"New Author ({b.Author}): ");
                    string author = Console.ReadLine() ?? "";
                    Console.Write($"New Publisher ({b.Publisher}): ");
                    string? pub = Console.ReadLine();
                    Console.Write($"New Category ({b.Category}): ");
                    string? cat = Console.ReadLine();

                    b.Title = string.IsNullOrWhiteSpace(title) ? b.Title : title;
                    b.Author = string.IsNullOrWhiteSpace(author) ? b.Author : author;
                    b.Publisher = string.IsNullOrWhiteSpace(pub) ? b.Publisher : pub;
                    b.Category = string.IsNullOrWhiteSpace(cat) ? b.Category : cat;

                    _service.Update(b);
                }
                else Console.WriteLine("Book not found.");
            }
        }

        private static void DeleteBook()
        {
            Console.Write("Book ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _service.Delete(id);
            }
        }
    }
}
