using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.BookLendingSystem.ConsoleApp
{
    public class BLSService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".", //(local) // server name
            InitialCatalog = "BookLendingSystem", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        #region Fetching Book
        public List<BookModel> Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT [book_id]
                           ,[title]
                           ,[author]
                           ,[publisher]
                           ,[category]
                     FROM [dbo].[Books] 
                     WHERE [del_flg] = 0";

            var result = db.Query<BookModel>(query).ToList();

            Console.WriteLine(result.Any() ? "Fetching book list successfully." : "No active books found.");

            return result;
           

        }
        #endregion
    
        public void Create(BookModel book)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"INSERT INTO [dbo].[Books]
                        ([title]
                        ,[author]
                        ,[publisher]
                        ,[category]
                        ,[created_at]
                        ,[del_flg])
                    VALUES
                        (@Title
                        ,@Author
                        ,@Publisher
                        ,@Category
                        ,GETDATE()
                        ,0)";

            var res = db.Execute(query,new
            {
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                Category = book.Category,
                CreatedAt = DateTime.Now,
                DelFlg = 0 // Active record
            });

            Console.WriteLine(res > 0 ? "Adding New Book Successfully" : "Fail To Add New Book On List");
            ;

        }
    
    }
}
