using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Members
{
    public class MemberService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public List<MemberViewModel> Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT [member_id]
                           ,[full_name]
                           ,[email]
                           ,[phone]
                           ,[role]
                           ,[status]
                           ,[created_at]
                     FROM [dbo].[Members]
                     WHERE [del_flg] = 0";

            var dataModels = db.Query<MemberDataModel>(query).ToList();

            var viewModels = dataModels.Select(d => new MemberViewModel
            {
                MemberId = d.member_id,
                FullName = d.full_name,
                Email = d.email,
                Phone = d.phone,
                Role = d.role,
                Status = d.status,
            }).ToList();

            Console.WriteLine(viewModels.Any() ? "Fetching member list successfully." : "No members found.");

            return viewModels;
        }

        public MemberViewModel? GetById(string memberId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT [member_id]
                           ,[full_name]
                           ,[email]
                           ,[phone]
                           ,[role]
                           ,[status]
                           ,[created_at]
                     FROM [dbo].[Members]
                     WHERE [member_id] = @MemberId AND [del_flg] = 0";

            var d = db.QueryFirstOrDefault<MemberDataModel>(query, new { MemberId = memberId });
            if (d == null) return null;

            return new MemberViewModel
            {
                MemberId = d.member_id,
                FullName = d.full_name,
                Email = d.email,
                Phone = d.phone,
                Role = d.role,
                Status = d.status,
            };
        }

        public void Create(MemberViewModel member)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"INSERT INTO [dbo].[Members]
                        ([member_id]
                        ,[full_name]
                        ,[email]
                        ,[phone]
                        ,[role]
                        ,[status]
                        ,[created_at])
                    VALUES
                        (@MemberId
                        ,@FullName
                        ,@Email
                        ,@Phone
                        ,@Role
                        ,@Status
                        ,GETDATE())";

            var res = db.Execute(query, new
            {
                MemberId = member.MemberId,
                FullName = member.FullName,
                Email = member.Email,
                Phone = member.Phone,
                Role = member.Role,
                Status = member.Status
            });

            Console.WriteLine(res > 0 ? "Adding New Member Successfully" : "Fail To Add New Member");
        }

        public void Update(MemberViewModel member)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Members]
                        SET [full_name] = @FullName
                           ,[email] = @Email
                           ,[phone] = @Phone
                           ,[role] = @Role
                           ,[status] = @Status
                      WHERE [member_id] = @MemberId";

            var res = db.Execute(query, new
            {
                MemberId = member.MemberId,
                FullName = member.FullName,
                Email = member.Email,
                Phone = member.Phone,
                Role = member.Role,
                Status = member.Status
            });

            Console.WriteLine(res > 0 ? "Updating Member Successfully" : "Fail To Update Member");
        }

        public void Delete(string memberId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Members] SET [del_flg] = 1 WHERE [member_id] = @MemberId";

            var res = db.Execute(query, new { MemberId = memberId });

            Console.WriteLine(res > 0 ? "Deleting Member Successfully" : "Fail To Delete Member");
        }
    }
}
