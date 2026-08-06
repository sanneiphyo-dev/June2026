using Dapper;
using June2026.BookLendingSystem.ConsoleApp.Features.Reservations.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Reservations
{
    public class ReservationService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public List<ReservationViewModel> Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT r.[reservation_id]
                           ,r.[book_id]
                           ,r.[member_id]
                           ,r.[reserved_at]
                           ,r.[status]
                           ,b.[title]
                           ,m.[full_name]
                     FROM [dbo].[Reservation] r
                     LEFT JOIN [dbo].[Books] b ON r.[book_id] = b.[book_id]
                     LEFT JOIN [dbo].[Members] m ON r.[member_id] = m.[member_id]";

            var dataModels = db.Query<ReservationDataModel>(query).ToList();

            var viewModels = dataModels.Select(d => new ReservationViewModel
            {
                ReservationId = d.reservation_id,
                BookId = d.book_id,
                MemberId = d.member_id,
                ReservedAt = d.reserved_at,
                Status = d.status,
                BookTitle = d.title,
                MemberName = d.full_name
            }).ToList();

            Console.WriteLine(viewModels.Any() ? "Fetching reservation list successfully." : "No reservations found.");

            return viewModels;
        }

        public ReservationViewModel? GetById(int reservationId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT r.[reservation_id]
                           ,r.[book_id]
                           ,r.[member_id]
                           ,r.[reserved_at]
                           ,r.[status]
                           ,b.[title]
                           ,m.[full_name]
                     FROM [dbo].[Reservation] r
                     LEFT JOIN [dbo].[Books] b ON r.[book_id] = b.[book_id]
                     LEFT JOIN [dbo].[Members] m ON r.[member_id] = m.[member_id]
                     WHERE r.[reservation_id] = @ReservationId";

            var d = db.QueryFirstOrDefault<ReservationDataModel>(query, new { ReservationId = reservationId });
            if (d == null) return null;

            return new ReservationViewModel
            {
                ReservationId = d.reservation_id,
                BookId = d.book_id,
                MemberId = d.member_id,
                ReservedAt = d.reserved_at,
                Status = d.status,
                BookTitle = d.title,
                MemberName = d.full_name
            };
        }

        public void Create(ReservationViewModel reservation)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"INSERT INTO [dbo].[Reservation]
                        ([book_id]
                        ,[member_id]
                        ,[reserved_at]
                        ,[status])
                    VALUES
                        (@BookId
                        ,@MemberId
                        ,GETDATE()
                        ,@Status)";

            var res = db.Execute(query, new
            {
                BookId = reservation.BookId,
                MemberId = reservation.MemberId,
                Status = reservation.Status
            });

            Console.WriteLine(res > 0 ? "Adding New Reservation Successfully" : "Fail To Add Reservation");
        }

        public void Update(ReservationViewModel reservation)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Reservation]
                        SET [book_id] = @BookId
                           ,[member_id] = @MemberId
                           ,[status] = @Status
                      WHERE [reservation_id] = @ReservationId";

            var res = db.Execute(query, new
            {
                ReservationId = reservation.ReservationId,
                BookId = reservation.BookId,
                MemberId = reservation.MemberId,
                Status = reservation.Status
            });

            Console.WriteLine(res > 0 ? "Updating Reservation Successfully" : "Fail To Update Reservation");
        }

        public void Delete(int reservationId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"DELETE FROM [dbo].[Reservation] WHERE [reservation_id] = @ReservationId";

            var res = db.Execute(query, new { ReservationId = reservationId });

            Console.WriteLine(res > 0 ? "Deleting Reservation Successfully" : "Fail To Delete Reservation");
        }
    }
}
