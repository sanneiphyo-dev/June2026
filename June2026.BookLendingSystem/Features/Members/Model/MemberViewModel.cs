using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Members.Model
{
    public class MemberViewModel
    {
        public string MemberId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Role { get; set; } = "Student";
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string DisplayText => $"[ID: {MemberId}] Name: {FullName} | Email: {Email} | Phone: {Phone ?? "N/A"} | Role: {Role} | Status: {Status}";
    }
}
