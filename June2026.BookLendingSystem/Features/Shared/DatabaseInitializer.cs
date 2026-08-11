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
                        created_at DATETIME2 DEFAULT GETDATE(),
                        del_flg BIT NOT NULL DEFAULT 0
                    );
                END

                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Book_Copies')
                BEGIN
                    CREATE TABLE Book_Copies (
                        copy_id VARCHAR(50) PRIMARY KEY,
                        book_id INT NOT NULL,
                        book_copy_count VARCHAR(50) NOT NULL,
                        del_flg BIT NOT NULL DEFAULT 0,
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
                        created_at DATETIME2 DEFAULT GETDATE(),
                        del_flg BIT NOT NULL DEFAULT 0
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
                        del_flg BIT NOT NULL DEFAULT 0,
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
                        del_flg BIT NOT NULL DEFAULT 0,
                        FOREIGN KEY (book_id) REFERENCES Books(book_id),
                        FOREIGN KEY (member_id) REFERENCES Members(member_id)
                    );
                END";

                db.Execute(script);

                // Run column existence migrations
                string migrationSql = @"
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Books') AND name = 'del_flg')
                BEGIN
                    ALTER TABLE Books ADD del_flg BIT NOT NULL DEFAULT 0;
                END
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Book_Copies') AND name = 'del_flg')
                BEGIN
                    ALTER TABLE Book_Copies ADD del_flg BIT NOT NULL DEFAULT 0;
                END
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Members') AND name = 'del_flg')
                BEGIN
                    ALTER TABLE Members ADD del_flg BIT NOT NULL DEFAULT 0;
                END
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Borrow_Transactions') AND name = 'del_flg')
                BEGIN
                    ALTER TABLE Borrow_Transactions ADD del_flg BIT NOT NULL DEFAULT 0;
                END
                IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Reservation') AND name = 'del_flg')
                BEGIN
                    ALTER TABLE Reservation ADD del_flg BIT NOT NULL DEFAULT 0;
                END";
                db.Execute(migrationSql);

                Console.WriteLine("Database schema initialized successfully.");

                SeedSampleData(db);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Schema Init Info]: {ex.Message}");
            }
        }

        private static void SeedSampleData(IDbConnection db)
        {
            try
            {
                // Check if Books table is empty, seed initial books
                int bookCount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Books");
                if (bookCount == 0)
                {
                    string seedBooks = @"
                        INSERT INTO Books (title, author, publisher, category) VALUES 
                        (N'C# 12 and .NET 8', N'Mark J. Price', N'Packt Publishing', N'Programming'),
                        (N'Clean Architecture', N'Robert C. Martin', N'Prentice Hall', N'Software Engineering'),
                        (N'Design Patterns', N'Erich Gamma et al.', N'Addison-Wesley', N'Computer Science');";
                    db.Execute(seedBooks);
                }

                // Check if Members table is empty
                int memberCount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Members");
                if (memberCount == 0)
                {
                    string seedMembers = @"
                        INSERT INTO Members (member_id, full_name, email, phone, role, status) VALUES 
                        ('MEM-1001', N'John Doe', 'john.doe@example.com', '09123456789', 'Student', 'Active'),
                        ('MEM-1002', N'Jane Smith', 'jane.smith@example.com', '09987654321', 'Teacher', 'Active');";
                    db.Execute(seedMembers);
                }

                // Check if Book_Copies is empty
                int copyCount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Book_Copies");
                if (copyCount == 0)
                {
                    int firstBookId = db.ExecuteScalar<int>("SELECT TOP 1 book_id FROM Books");
                    if (firstBookId > 0)
                    {
                        string seedCopies = $@"
                            INSERT INTO Book_Copies (copy_id, book_id, book_copy_count) VALUES 
                            ('CC-COPY-01', {firstBookId}, '1'),
                            ('CC-COPY-02', {firstBookId}, '2');";
                        db.Execute(seedCopies);
                    }
                }

                // Check if Borrow_Transactions is empty
                int txnCount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Borrow_Transactions");
                if (txnCount == 0)
                {
                    string seedTxn = @"
                        INSERT INTO Borrow_Transactions (transaction_id, member_id, copy_id, borrow_date, due_date, status) VALUES 
                        ('TXN-2026-0001', 'MEM-1001', 'CC-COPY-01', GETDATE(), DATEADD(day, 14, GETDATE()), 'Borrowed');";
                    db.Execute(seedTxn);
                }

                // Check if Reservation is empty
                int resCount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM Reservation");
                if (resCount == 0)
                {
                    int firstBookId = db.ExecuteScalar<int>("SELECT TOP 1 book_id FROM Books");
                    if (firstBookId > 0)
                    {
                        string seedRes = $@"
                            INSERT INTO Reservation (book_id, member_id, reserved_at, status) VALUES 
                            ({firstBookId}, 'MEM-1002', GETDATE(), 'Pending');";
                        db.Execute(seedRes);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Seed Info]: {ex.Message}");
            }
        }
    }
}
