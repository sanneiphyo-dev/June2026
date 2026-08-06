using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BookCopies
{
    public class BookCopyService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public List<BookCopyViewModel> Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT bc.[copy_id]
                           ,bc.[book_id]
                           ,bc.[book_copy_count]
                           ,b.[title]
                     FROM [dbo].[Book_Copies] bc
                     LEFT JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]";

            var dataModels = db.Query<BookCopyDataModel>(query).ToList();

            var viewModels = dataModels.Select(d => new BookCopyViewModel
            {
                CopyId = d.copy_id,
                BookId = d.book_id,
                BookCopyCount = d.book_copy_count,
                BookTitle = d.title
            }).ToList();

            Console.WriteLine(viewModels.Any() ? "Fetching book copy list successfully." : "No book copies found.");

            return viewModels;
        }

        public BookCopyViewModel? GetById(string copyId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT bc.[copy_id]
                           ,bc.[book_id]
                           ,bc.[book_copy_count]
                           ,b.[title]
                     FROM [dbo].[Book_Copies] bc
                     LEFT JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                     WHERE bc.[copy_id] = @CopyId";

            var d = db.QueryFirstOrDefault<BookCopyDataModel>(query, new { CopyId = copyId });
            if (d == null) return null;

            return new BookCopyViewModel
            {
                CopyId = d.copy_id,
                BookId = d.book_id,
                BookCopyCount = d.book_copy_count,
                BookTitle = d.title
            };
        }

        public void Create(BookCopyViewModel copy)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"INSERT INTO [dbo].[Book_Copies]
                        ([copy_id]
                        ,[book_id]
                        ,[book_copy_count])
                    VALUES
                        (@CopyId
                        ,@BookId
                        ,@BookCopyCount)";

            var res = db.Execute(query, new
            {
                CopyId = copy.CopyId,
                BookId = copy.BookId,
                BookCopyCount = copy.BookCopyCount
            });

            Console.WriteLine(res > 0 ? "Adding New Book Copy Successfully" : "Fail To Add New Book Copy");
        }

        public void Update(BookCopyViewModel copy)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Book_Copies]
                        SET [book_id] = @BookId
                           ,[book_copy_count] = @BookCopyCount
                      WHERE [copy_id] = @CopyId";

            var res = db.Execute(query, new
            {
                CopyId = copy.CopyId,
                BookId = copy.BookId,
                BookCopyCount = copy.BookCopyCount
            });

            Console.WriteLine(res > 0 ? "Updating Book Copy Successfully" : "Fail To Update Book Copy");
        }

        public void Delete(string copyId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"DELETE FROM [dbo].[Book_Copies] WHERE [copy_id] = @CopyId";

            var res = db.Execute(query, new { CopyId = copyId });

            Console.WriteLine(res > 0 ? "Deleting Book Copy Successfully" : "Fail To Delete Book Copy");
        }
    }
}
