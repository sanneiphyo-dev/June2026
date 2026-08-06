using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Members
{
    public static class MemberUI
    {
        private static readonly MemberService _service = new MemberService();

        public static void Run()
        {
            Console.WriteLine("\n--- MEMBER MANAGEMENT ---");
            Console.WriteLine("1. Add Member");
            Console.WriteLine("2. View All Members");
            Console.WriteLine("3. Find Member by ID");
            Console.WriteLine("4. Update Member");
            Console.WriteLine("5. Delete Member");
            Console.Write("Select: ");

            switch (Console.ReadLine())
            {
                case "1": AddMember(); break;
                case "2": ViewMembers(); break;
                case "3": FindMember(); break;
                case "4": UpdateMember(); break;
                case "5": DeleteMember(); break;
            }
        }

        private static void AddMember()
        {
            Console.Write("Member ID (e.g. MEM-1082): ");
            string id = Console.ReadLine() ?? "";
            Console.Write("Full Name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Phone: ");
            string? phone = Console.ReadLine();
            Console.Write("Role (Student/Teacher/Staff): ");
            string role = Console.ReadLine() ?? "Student";
            Console.Write("Status (Active/Inactive): ");
            string status = Console.ReadLine() ?? "Active";

            _service.Create(new MemberViewModel
            {
                MemberId = id,
                FullName = name,
                Email = email,
                Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                Role = string.IsNullOrWhiteSpace(role) ? "Student" : role,
                Status = string.IsNullOrWhiteSpace(status) ? "Active" : status
            });
        }

        private static void ViewMembers()
        {
            var members = _service.Read();
            foreach (var m in members)
            {
                Console.WriteLine(m.DisplayText);
            }
        }

        private static void FindMember()
        {
            Console.Write("Member ID: ");
            string id = Console.ReadLine() ?? "";
            var m = _service.GetById(id);
            if (m != null)
                Console.WriteLine(m.DisplayText);
            else
                Console.WriteLine("Member not found.");
        }

        private static void UpdateMember()
        {
            Console.Write("Member ID to Update: ");
            string id = Console.ReadLine() ?? "";
            var m = _service.GetById(id);
            if (m != null)
            {
                Console.Write($"New Full Name ({m.FullName}): ");
                string name = Console.ReadLine() ?? "";
                Console.Write($"New Email ({m.Email}): ");
                string email = Console.ReadLine() ?? "";
                Console.Write($"New Phone ({m.Phone}): ");
                string? phone = Console.ReadLine();
                Console.Write($"New Role ({m.Role}): ");
                string role = Console.ReadLine() ?? "";
                Console.Write($"New Status ({m.Status}): ");
                string status = Console.ReadLine() ?? "";

                m.FullName = string.IsNullOrWhiteSpace(name) ? m.FullName : name;
                m.Email = string.IsNullOrWhiteSpace(email) ? m.Email : email;
                m.Phone = string.IsNullOrWhiteSpace(phone) ? m.Phone : phone;
                m.Role = string.IsNullOrWhiteSpace(role) ? m.Role : role;
                m.Status = string.IsNullOrWhiteSpace(status) ? m.Status : status;

                _service.Update(m);
            }
            else Console.WriteLine("Member not found.");
        }

        private static void DeleteMember()
        {
            Console.Write("Member ID to Delete: ");
            string id = Console.ReadLine() ?? "";
            _service.Delete(id);
        }
    }
}
