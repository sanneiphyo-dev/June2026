using System;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Members
{
    public class MemberDataModel
    {
        public string member_id { get; set; } = string.Empty;
        public string full_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string? phone { get; set; }
        public string role { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public DateTime created_at { get; set; } = DateTime.Now;
    }
}
