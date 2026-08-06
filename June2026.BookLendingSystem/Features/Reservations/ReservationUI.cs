using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Reservations
{
    public static class ReservationUI
    {
        private static readonly ReservationService _service = new ReservationService();

        public static void Run()
        {
            Console.WriteLine("\n--- RESERVATION MANAGEMENT ---");
            Console.WriteLine("1. Create Reservation");
            Console.WriteLine("2. View All Reservations");
            Console.WriteLine("3. Find Reservation by ID");
            Console.WriteLine("4. Update Reservation Status");
            Console.WriteLine("5. Delete Reservation");
            Console.Write("Select: ");

            switch (Console.ReadLine())
            {
                case "1": AddReservation(); break;
                case "2": ViewReservations(); break;
                case "3": FindReservation(); break;
                case "4": UpdateReservation(); break;
                case "5": DeleteReservation(); break;
            }
        }

        private static void AddReservation()
        {
            Console.Write("Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                Console.Write("Member ID: ");
                string memberId = Console.ReadLine() ?? "";
                Console.Write("Status (default 'Pending'): ");
                string status = Console.ReadLine() ?? "Pending";

                _service.Create(new ReservationViewModel
                {
                    BookId = bookId,
                    MemberId = memberId,
                    Status = string.IsNullOrWhiteSpace(status) ? "Pending" : status
                });
            }
        }

        private static void ViewReservations()
        {
            var list = _service.Read();
            foreach (var r in list)
            {
                Console.WriteLine(r.DisplayText);
            }
        }

        private static void FindReservation()
        {
            Console.Write("Reservation ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var r = _service.GetById(id);
                if (r != null)
                    Console.WriteLine(r.DisplayText);
                else
                    Console.WriteLine("Reservation not found.");
            }
        }

        private static void UpdateReservation()
        {
            Console.Write("Reservation ID to Update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var r = _service.GetById(id);
                if (r != null)
                {
                    Console.Write($"New Status (Current: {r.Status}): ");
                    string status = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(status)) r.Status = status;

                    _service.Update(r);
                }
                else Console.WriteLine("Reservation not found.");
            }
        }

        private static void DeleteReservation()
        {
            Console.Write("Reservation ID to Delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _service.Delete(id);
            }
        }
    }
}
