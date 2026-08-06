using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Books
{
    public class BookService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        #region Fetching Books
        public List<BookViewModel> Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT [book_id]
                           ,[title]
                           ,[author]
                           ,[publisher]
                           ,[category]
                           ,[created_at]
                     FROM [dbo].[Books]";

            var dataModels = db.Query<BookDataModel>(query).ToList();

            var viewModels = dataModels.Select(d => new BookViewModel
            {
                BookId = d.book_id,
                Title = d.title,
                Author = d.author,
                Publisher = d.publisher,
                Category = d.category,
                CreatedAt = d.created_at
            }).ToList();

            Console.WriteLine(viewModels.Any() ? "Fetching book list successfully." : "No active books found.");

            return viewModels;
        }

        public BookViewModel? GetById(int bookId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT [book_id]
                           ,[title]
                           ,[author]
                           ,[publisher]
                           ,[category]
                           ,[created_at]
                     FROM [dbo].[Books]
                     WHERE [book_id] = @BookId";

            var d = db.QueryFirstOrDefault<BookDataModel>(query, new { BookId = bookId });
            if (d == null) return null;

            return new BookViewModel
            {
                BookId = d.book_id,
                Title = d.title,
                Author = d.author,
                Publisher = d.publisher,
                Category = d.category,
                CreatedAt = d.created_at
            };
        }
        #endregion

        #region Create Book
        public void Create(BookViewModel book)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"INSERT INTO [dbo].[Books]
                        ([title]
                        ,[author]
                        ,[publisher]
                        ,[category]
                        ,[created_at])
                    VALUES
                        (@Title
                        ,@Author
                        ,@Publisher
                        ,@Category
                        ,GETDATE())";

            var res = db.Execute(query, new
            {
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Category = book.Category
            });

            Console.WriteLine(res > 0 ? "Adding New Book Successfully" : "Fail To Add New Book On List");
        }
        #endregion

        #region Update Book
        public void Update(BookViewModel book)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Books]
                        SET [title] = @Title
                           ,[author] = @Author
                           ,[publisher] = @Publisher
                           ,[category] = @Category
                      WHERE [book_id] = @BookId";

            var res = db.Execute(query, new
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Category = book.Category
            });

            Console.WriteLine(res > 0 ? "Updating Book Successfully" : "Fail To Update Book");
        }
        #endregion

        #region Delete Book
        public void Delete(int bookId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"DELETE FROM [dbo].[Books] WHERE [book_id] = @BookId";

            var res = db.Execute(query, new { BookId = bookId });

            Console.WriteLine(res > 0 ? "Deleting Book Successfully" : "Fail To Delete Book");
        }
        #endregion
    }
}
