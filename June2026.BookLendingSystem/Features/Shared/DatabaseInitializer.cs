using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace June2026.BookLendingSystem.ConsoleApp.Features.Shared
{
    public static class DatabaseInitializer
    {
        private static readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".", // (local) server name
            InitialCatalog = "BookLendingSystem", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public static string ConnectionString => sb.ConnectionString;

        public static void InitDatabaseSchema()
        {
            try
            {
                var masterSb = new SqlConnectionStringBuilder(sb.ConnectionString) { InitialCatalog = "master" };
                using (IDbConnection masterDb = new SqlConnection(masterSb.ConnectionString))
                {
                    string createDbSql = @"
                        IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'BookLendingSystem')
                        BEGIN
                            CREATE DATABASE [BookLendingSystem];
                        END";
                    masterDb.Execute(createDbSql);
                }

                using IDbConnection db = new SqlConnection(sb.ConnectionString);
                string script = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Books')
                BEGIN
                    CREATE TABLE Books (
                        book_id INT IDENTITY(1,1) PRIMARY KEY,
                        title NVARCHAR(255) NOT NULL,
                        author NVARCHAR(255) NOT NULL,
                        publisher NVARCHAR(255) NULL,
                        category NVARCHAR(100) NULL,
                        created_at DATETIME2 DEFAULT GETDATE()
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Book_Copies')
                BEGIN
                    CREATE TABLE Book_Copies (
                        copy_id VARCHAR(50) PRIMARY KEY,
                        book_id INT NOT NULL,
                        book_copy_count VARCHAR(50) NOT NULL,
                        FOREIGN KEY (book_id) REFERENCES Books(book_id) ON DELETE CASCADE
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Members')
                BEGIN
                    CREATE TABLE Members (
                        member_id VARCHAR(50) PRIMARY KEY,
                        full_name NVARCHAR(100) NOT NULL,
                        email VARCHAR(100) NOT NULL UNIQUE,
                        phone VARCHAR(20) NULL,
                        role VARCHAR(20) NOT NULL,
                        status VARCHAR(20) NOT NULL,
                        created_at DATETIME2 DEFAULT GETDATE()
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Borrow_Transactions')
                BEGIN
                    CREATE TABLE Borrow_Transactions (
                        transaction_id VARCHAR(50) PRIMARY KEY,
                        member_id VARCHAR(50) NOT NULL,
                        copy_id VARCHAR(50) NOT NULL,
                        borrow_date DATETIME2 DEFAULT GETDATE() NOT NULL,
                        due_date DATETIME2 NOT NULL,
                        return_date DATETIME2 NULL,
                        fine_amount DECIMAL(10, 2) DEFAULT 0.00 NOT NULL,
                        status VARCHAR(20) NOT NULL,
                        FOREIGN KEY (member_id) REFERENCES Members(member_id),
                        FOREIGN KEY (copy_id) REFERENCES Book_Copies(copy_id)
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reservation')
                BEGIN
                    CREATE TABLE Reservation (
                        reservation_id INT IDENTITY(1,1) PRIMARY KEY,
                        book_id INT NOT NULL,
                        member_id VARCHAR(50) NOT NULL,
                        reserved_at DATETIME2 DEFAULT GETDATE() NOT NULL,
                        status VARCHAR(20) NOT NULL,
                        FOREIGN KEY (book_id) REFERENCES Books(book_id),
                        FOREIGN KEY (member_id) REFERENCES Members(member_id)
                    );
                END";

                db.Execute(script);
                Console.WriteLine("Database schema initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Schema Init Info]: {ex.Message}");
            }
        }
    }
}
