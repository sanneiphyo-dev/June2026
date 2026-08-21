using Dapper;
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
                     LEFT JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                     WHERE bt.[del_flg] = 0";

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
                     WHERE bt.[transaction_id] = @TransactionId AND bt.[del_flg] = 0";

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

            // 1. Verify if the member exists
            string checkMemberQuery = "SELECT COUNT(*) FROM [dbo].[Members] WHERE [member_id] = @MemberId AND [del_flg] = 0";
            int memberExists = db.ExecuteScalar<int>(checkMemberQuery, new { MemberId = transaction.MemberId });
            if (memberExists == 0)
            {
                throw new InvalidOperationException($"Member ID '{transaction.MemberId}' does not exist.");
            }

            // 2. Verify if the copy is already borrowed
            if (transaction.Status == "Borrowed")
            {
                string checkQuery = @"SELECT COUNT(*) FROM [dbo].[Borrow_Transactions] 
                                      WHERE [copy_id] = @CopyId AND [status] = 'Borrowed' AND [del_flg] = 0";
                int activeLoans = db.ExecuteScalar<int>(checkQuery, new { CopyId = transaction.CopyId });
                if (activeLoans > 0)
                {
                    throw new InvalidOperationException("No copies available. This book is currently out of stock.");
                }
            }

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

            // 1. Verify if the member exists
            string checkMemberQuery = "SELECT COUNT(*) FROM [dbo].[Members] WHERE [member_id] = @MemberId AND [del_flg] = 0";
            int memberExists = db.ExecuteScalar<int>(checkMemberQuery, new { MemberId = transaction.MemberId });
            if (memberExists == 0)
            {
                throw new InvalidOperationException($"Member ID '{transaction.MemberId}' does not exist.");
            }

            // 2. Fetch the old status and copy ID to see if it transitioned to Returned
            string statusQuery = "SELECT [status], [copy_id] FROM [dbo].[Borrow_Transactions] WHERE [transaction_id] = @TransactionId";
            var oldRecord = db.QueryFirstOrDefault<(string status, string copy_id)>(statusQuery, new { TransactionId = transaction.TransactionId });

            // 3. Verify if the copy is already borrowed by another active transaction
            if (transaction.Status == "Borrowed")
            {
                string checkQuery = @"SELECT COUNT(*) FROM [dbo].[Borrow_Transactions] 
                                      WHERE [copy_id] = @CopyId AND [status] = 'Borrowed' AND [transaction_id] != @TransactionId AND [del_flg] = 0";
                int activeLoans = db.ExecuteScalar<int>(checkQuery, new { CopyId = transaction.CopyId, TransactionId = transaction.TransactionId });
                if (activeLoans > 0)
                {
                    throw new InvalidOperationException("No copies available. This book is currently out of stock.");
                }
            }

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

            // 4. Process Reservation Waiting List if transitioned to "Returned"
            if (oldRecord != default && oldRecord.status != "Returned" && transaction.Status == "Returned")
            {
                // Find book_id of this copy_id
                string bookIdQuery = "SELECT [book_id] FROM [dbo].[Book_Copies] WHERE [copy_id] = @CopyId";
                int bookId = db.QueryFirstOrDefault<int>(bookIdQuery, new { CopyId = transaction.CopyId });

                if (bookId > 0)
                {
                    // Find the oldest pending reservation for this book
                    string resQuery = @"SELECT TOP 1 [reservation_id], [member_id] 
                                        FROM [dbo].[Reservation] 
                                        WHERE [book_id] = @BookId AND [status] = 'Pending' AND [del_flg] = 0 
                                        ORDER BY [reservation_id] ASC";
                    var oldestRes = db.QueryFirstOrDefault<(int reservation_id, string member_id)>(resQuery, new { BookId = bookId });

                    if (oldestRes != default)
                    {
                        // Automatically create a borrow transaction for this reservation member
                        string newTxnId = $"TXN-2026-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}";
                        string insertTxnSql = @"INSERT INTO [dbo].[Borrow_Transactions]
                                                ([transaction_id]
                                                ,[member_id]
                                                ,[copy_id]
                                                ,[borrow_date]
                                                ,[due_date]
                                                ,[status])
                                            VALUES
                                                (@TransactionId
                                                ,@MemberId
                                                ,@CopyId
                                                ,GETDATE()
                                                ,DATEADD(day, 14, GETDATE())
                                                ,'Borrowed')";
                        db.Execute(insertTxnSql, new
                        {
                            TransactionId = newTxnId,
                            MemberId = oldestRes.member_id,
                            CopyId = transaction.CopyId
                        });

                        // Update the reservation status to 'Completed'
                        string updateResSql = "UPDATE [dbo].[Reservation] SET [status] = 'Completed' WHERE [reservation_id] = @ReservationId";
                        db.Execute(updateResSql, new { ReservationId = oldestRes.reservation_id });
                    }
                }
            }
        }

        public void Delete(string transactionId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);

            string query = @"UPDATE [dbo].[Borrow_Transactions] SET [del_flg] = 1 WHERE [transaction_id] = @TransactionId";

            var res = db.Execute(query, new { TransactionId = transactionId });

            Console.WriteLine(res > 0 ? "Deleting Borrow Transaction Successfully" : "Fail To Delete Transaction");
        }

        public string? GetCopyIdByBookTitle(string bookTitle)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            string query = @"SELECT TOP 1 bc.[copy_id]
                             FROM [dbo].[Book_Copies] bc
                             INNER JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                             WHERE b.[title] = @BookTitle 
                               AND bc.[del_flg] = 0
                               AND b.[del_flg] = 0
                               AND bc.[copy_id] NOT IN (
                                   SELECT bt.[copy_id] 
                                   FROM [dbo].[Borrow_Transactions] bt 
                                   WHERE bt.[status] = 'Borrowed' AND bt.[del_flg] = 0
                               )";
            return db.QueryFirstOrDefault<string>(query, new { BookTitle = bookTitle });
        }

        public int GetTotalCopiesByBookTitle(string bookTitle)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            string query = @"SELECT COUNT(*) 
                             FROM [dbo].[Book_Copies] bc
                             INNER JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                             WHERE b.[title] = @BookTitle AND bc.[del_flg] = 0 AND b.[del_flg] = 0";
            return db.ExecuteScalar<int>(query, new { BookTitle = bookTitle });
        }

        public int GetAvailableCopiesByBookTitle(string bookTitle)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            string query = @"SELECT COUNT(*)
                             FROM [dbo].[Book_Copies] bc
                             INNER JOIN [dbo].[Books] b ON bc.[book_id] = b.[book_id]
                             WHERE b.[title] = @BookTitle 
                               AND bc.[del_flg] = 0 
                               AND b.[del_flg] = 0
                               AND bc.[copy_id] NOT IN (
                                   SELECT bt.[copy_id] 
                                   FROM [dbo].[Borrow_Transactions] bt 
                                   WHERE bt.[status] = 'Borrowed' AND bt.[del_flg] = 0
                               )";
            return db.ExecuteScalar<int>(query, new { BookTitle = bookTitle });
        }

        public int? GetBookIdByBookTitle(string bookTitle)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            string query = @"SELECT TOP 1 [book_id] 
                             FROM [dbo].[Books] 
                             WHERE [title] = @BookTitle AND [del_flg] = 0";
            return db.QueryFirstOrDefault<int?>(query, new { BookTitle = bookTitle });
        }

        public bool CheckMemberExists(string memberId)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            string query = "SELECT COUNT(*) FROM [dbo].[Members] WHERE [member_id] = @MemberId AND [del_flg] = 0";
            return db.ExecuteScalar<int>(query, new { MemberId = memberId }) > 0;
        }
    }
}
