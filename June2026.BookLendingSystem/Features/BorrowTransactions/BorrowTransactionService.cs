using Dapper;
using June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace June2026.BookLendingSystem.ConsoleApp.Features.BorrowTransactions
{
    public class BorrowTransactionService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "BookLendingSystem",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public List<BorrowTransactionViewModel> Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT bt.[transaction_id]
                           ,bt.[member_id]
                           ,bt.[copy_id]
                           ,bt.[borrow_date]
                           ,bt.[due_date]
                           ,bt.[return_date]
                           ,bt.[fine_amount]
                           ,bt.[status]
                           ,m.[full_name]
                           ,b.[title]
                     FROM [dbo].[Borrow_Transactions] bt
                     LEFT JOIN [dbo].[Members] m ON bt.[member_id] = m.[member_id]
                     LEFT JOIN [dbo].[Book_Copies] bc ON bt.[copy_id] = bc.[copy_id]
                     LEFT JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]";

            var dataModels = db.Query<BorrowTransactionDataModel>(query).ToList();

            var viewModels = dataModels.Select(d => new BorrowTransactionViewModel
            {
                TransactionId = d.transaction_id,
                MemberId = d.member_id,
                CopyId = d.copy_id,
                BorrowDate = d.borrow_date,
                DueDate = d.due_date,
                ReturnDate = d.return_date,
                FineAmount = d.fine_amount,
                Status = d.status,
                MemberName = d.full_name,
                BookTitle = d.title
            }).ToList();

            Console.WriteLine(viewModels.Any() ? "Fetching transaction list successfully." : "No transactions found.");

            return viewModels;
        }

        public BorrowTransactionViewModel? GetById(string transactionId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"SELECT bt.[transaction_id]
                           ,bt.[member_id]
                           ,bt.[copy_id]
                           ,bt.[borrow_date]
                           ,bt.[due_date]
                           ,bt.[return_date]
                           ,bt.[fine_amount]
                           ,bt.[status]
                           ,m.[full_name]
                           ,b.[title]
                     FROM [dbo].[Borrow_Transactions] bt
                     LEFT JOIN [dbo].[Members] m ON bt.[member_id] = m.[member_id]
                     LEFT JOIN [dbo].[Book_Copies] bc ON bt.[copy_id] = bc.[copy_id]
                     LEFT JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                     WHERE bt.[transaction_id] = @TransactionId";

            var d = db.QueryFirstOrDefault<BorrowTransactionDataModel>(query, new { TransactionId = transactionId });
            if (d == null) return null;

            return new BorrowTransactionViewModel
            {
                TransactionId = d.transaction_id,
                MemberId = d.member_id,
                CopyId = d.copy_id,
                BorrowDate = d.borrow_date,
                DueDate = d.due_date,
                ReturnDate = d.return_date,
                FineAmount = d.fine_amount,
                Status = d.status,
                MemberName = d.full_name,
                BookTitle = d.title
            };
        }

        public void Create(BorrowTransactionViewModel transaction)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"INSERT INTO [dbo].[Borrow_Transactions]
                        ([transaction_id]
                        ,[member_id]
                        ,[copy_id]
                        ,[borrow_date]
                        ,[due_date]
                        ,[return_date]
                        ,[fine_amount]
                        ,[status])
                    VALUES
                        (@TransactionId
                        ,@MemberId
                        ,@CopyId
                        ,GETDATE()
                        ,@DueDate
                        ,@ReturnDate
                        ,@FineAmount
                        ,@Status)";

            var res = db.Execute(query, new
            {
                TransactionId = transaction.TransactionId,
                MemberId = transaction.MemberId,
                CopyId = transaction.CopyId,
                DueDate = transaction.DueDate,
                ReturnDate = transaction.ReturnDate,
                FineAmount = transaction.FineAmount,
                Status = transaction.Status
            });

            Console.WriteLine(res > 0 ? "Adding New Borrow Transaction Successfully" : "Fail To Add Borrow Transaction");
        }

        public void Update(BorrowTransactionViewModel transaction)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Borrow_Transactions]
                        SET [member_id] = @MemberId
                           ,[copy_id] = @CopyId
                           ,[due_date] = @DueDate
                           ,[return_date] = @ReturnDate
                           ,[fine_amount] = @FineAmount
                           ,[status] = @Status
                      WHERE [transaction_id] = @TransactionId";

            var res = db.Execute(query, new
            {
                TransactionId = transaction.TransactionId,
                MemberId = transaction.MemberId,
                CopyId = transaction.CopyId,
                DueDate = transaction.DueDate,
                ReturnDate = transaction.ReturnDate,
                FineAmount = transaction.FineAmount,
                Status = transaction.Status
            });

            Console.WriteLine(res > 0 ? "Updating Borrow Transaction Successfully" : "Fail To Update Transaction");
        }

        public void Delete(string transactionId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"DELETE FROM [dbo].[Borrow_Transactions] WHERE [transaction_id] = @TransactionId";

            var res = db.Execute(query, new { TransactionId = transactionId });

            Console.WriteLine(res > 0 ? "Deleting Borrow Transaction Successfully" : "Fail To Delete Transaction");
        }
    }
}
