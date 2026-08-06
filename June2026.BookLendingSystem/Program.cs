using System;
using June2026.BookLendingSystem.ConsoleApp.Features.Books;
using June2026.BookLendingSystem.ConsoleApp.Features.BookCopies;
using June2026.BookLendingSystem.ConsoleApp.Features.Members;
using June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions;
using June2026.BookLendingSystem.ConsoleApp.Features.Reservations;
using June2026.BookLendingSystem.ConsoleApp.Features.Shared;

namespace June2026.BookLendingSystem.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("    BOOK LENDING SYSTEM - CONSOLE APPLICATION    ");

            DatabaseInitializer.InitDatabaseSchema();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n---------------- MAIN MENU ----------------");
                Console.WriteLine("1. Manage Books");
                Console.WriteLine("2. Manage Book Copies");
                Console.WriteLine("3. Manage Members");
                Console.WriteLine("4. Manage Borrow Transactions");
                Console.WriteLine("5. Manage Reservations");
                Console.WriteLine("6. Re-Initialize Database Schema");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1": BookUI.Run(); break;
                    case "2": BookCopyUI.Run(); break;
                    case "3": MemberUI.Run(); break;
                    case "4": BorrowTransactionUI.Run(); break;
                    case "5": ReservationUI.Run(); break;
                    case "6": DatabaseInitializer.InitDatabaseSchema(); break;
                    case "0": exit = true; Console.WriteLine("Exiting Book Lending System. Goodbye!"); break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }
            }
        }
    }
}