using System;
using System.ComponentModel;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Members
{
    public class MemberViewModel
    {
        public string MemberId { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        [Browsable(false)]
        public string DisplayText => $"| MemberId: {MemberId} |Member Name: {FullName} | Email: {Email} | Phone: {Phone ?? "N/A"} | Role: {Role} | Status: {Status}";
    }
}
