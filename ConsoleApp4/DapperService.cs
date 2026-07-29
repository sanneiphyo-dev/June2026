using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp4
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".", //(local) // server name
            InitialCatalog = "June2026Db", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            List<StudentDto> lst = db.Query<StudentDto>("SELECT * FROM [dbo].[Tbl_Student];").ToList();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id: {item.StudentID}, Name: {item.StudentName}");
            }
            db.Close();

        }
        
        public void Create()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int res = db.Execute(@"INSERT INTO Tbl_Student
                            (
                                StudentName,
                                FatherName,
                                StudentNo,
                                Email,
                                MobileNo,
                                IsDelete
                            )
                            VALUES
                            (
                                'John Doe',
                                'Michael Doe',
                                'STU001',
                                'john.doe@gmail.com',
                                '09123456789',
                                0
                            );");
            Console.WriteLine($"Rows Created: {res}");
            db.Close();
        }

        public void Update()
            {
                    using IDbConnection db = new SqlConnection(sb.ConnectionString);
                    db.Open();

                    int res = db.Execute(@"
                UPDATE Tbl_Student
                SET
                    StudentName = 'Jane Doe',
                    FatherName = 'David Doe',
                    StudentNo = 'STU001',
                    Email = 'jane.doe@gmail.com',
                    MobileNo = '09987654321',
                    IsDelete = 0
                WHERE StudentID = 5;
            ");

                    Console.WriteLine($"Rows Updated: {res}");

                    db.Close();
                }

        public void Delete() { 
        
            using IDbConnection db = new SqlConnection( sb.ConnectionString);

            int res = db.Execute(@"
                DELETE FROM Tbl_Student
                WHERE StudentID = 7;
            ");

            Console.WriteLine($"Rows Updated: {res}");
        }
    
    
    }


};
