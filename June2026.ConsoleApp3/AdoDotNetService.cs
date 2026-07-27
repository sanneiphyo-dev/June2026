using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace June2026.ConsoleApp3
{
    internal class AdoDotNetService
    {
        public void ReadExecuteReader()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = ".";
            sb.InitialCatalog = "June2026Db";
            sb.UserID = "sa";
            sb.Password = "sasa@123";
            sb.TrustServerCertificate = true;

            Console.WriteLine($"connection stirng: {sb.ConnectionString}");

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            Console.WriteLine("Connection Opening.......");
            connection.Open();
            Console.WriteLine("Connection Opened.......");
            string query = @"SELECT [StudentID]
                  ,[StudentName]
                  ,[FatherName]
                  ,[StudentNo]
                  ,[Email]
                  ,[MobileNo]
                  ,[IsDelete]
              FROM [dbo].[Tbl_Student] WHERE IsDelete='0' ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dt = new DataTable();
            //dataAdapter.Fill(dt);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["StudentName"]);
                Console.WriteLine(reader["FatherName"]);
                Console.WriteLine(reader["StudentNo"]);
                Console.WriteLine(reader["Email"]);
                Console.WriteLine(reader["DateOfBirth"]);
                Console.WriteLine(reader["MobileNo"]);
            }
            ;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["StudentName"]);
            //    Console.WriteLine(dr["FatherName"]);
            //    Console.WriteLine(dr["StudentNo"]);
            //    Console.WriteLine(dr["Email"]);
            //    Console.WriteLine(dr["DateOfBirth"]);
            //    Console.WriteLine(dr["MobileNo"]);
            //}
            Console.WriteLine("Connection Closed.......");

            Console.WriteLine("Connection Closing.......");
            connection.Close();

            //DataSet
            //DataTable
            //DataColumn
            //DataRow


        }

        public void ReadWithDataAdapter()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = ".";
            sb.InitialCatalog = "June2026Db";
            sb.UserID = "sa";
            sb.Password = "sasa@123";
            sb.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            Console.WriteLine("Connection Opening.......");
            connection.Open();
            Console.WriteLine("Connection Opened.......");
            string query = @"SELECT [StudentID]
                  ,[StudentName]
                  ,[FatherName]
                  ,[StudentNo]
                  ,[Email]
                  ,[MobileNo]
                  ,[IsDelete]
              FROM [dbo].[Tbl_Student] WHERE IsDelete='0' ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            Console.WriteLine("Connection Closing.......");
            connection.Close();

            //DataSet
            //DataTable
            //DataColumn
            //DataRow

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["StudentName"]);
                Console.WriteLine(dr["FatherName"]);
                Console.WriteLine(dr["StudentNo"]);
                Console.WriteLine(dr["Email"]);
                Console.WriteLine(dr["DateOfBirth"]);
                Console.WriteLine(dr["MobileNo"]);
            }
            Console.WriteLine("Connection Closed.......");
        }

        public void Create()
        {
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter Father Name: ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter Student No: ");
            string studentNo = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

           // Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
           // string dateOfBirthInput = Console.ReadLine();

            Console.Write("Enter Mobile No: ");
            string mobileNo = Console.ReadLine();

            Console.WriteLine("Inserting record into the database...");

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = ".";
            sb.InitialCatalog = "June2026Db";
            sb.UserID = "sa";
            sb.Password = "sasa@123";
            sb.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is openning .... ");
            Console.WriteLine("Connection is opened .... ");
            string query = @"INSERT INTO [dbo].[Tbl_Student]
                           ([StudentName]
                           ,[FatherName]
                           ,[StudentNo]
                           ,[Email]
                           ,[MobileNo]
                           ,[IsDelete])
                     VALUES
                           (@StudentName
                           ,@FatherName
                           ,@StudentNo
                           ,@Email
                           ,@MobileNo
                           ,0)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StudentName", studentName);
            cmd.Parameters.AddWithValue("@FatherName", fatherName);
            cmd.Parameters.AddWithValue("@StudentNo", studentNo);
            cmd.Parameters.AddWithValue("@Email",email);
            cmd.Parameters.AddWithValue("@MobileNo",mobileNo);

            int result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Record Inserted Successfully" : "Record Not Inserted";

            Console.WriteLine("Connection is closing ");
            Console.WriteLine("Connection is closed ");
            connection.Close();
        }
  
        public void Update()
        {
            Console.Write("Enter Student Id: ");
            int StudentId = Convert.ToInt32(Console.ReadLine());

            // Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            // string dateOfBirthInput = Console.ReadLine();

            Console.Write("Enter Mobile No: ");
            string mobileNo = Console.ReadLine();

            Console.WriteLine("Inserting record into the database...");

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = ".";
            sb.InitialCatalog = "June2026Db";
            sb.UserID = "sa";
            sb.Password = "sasa@123";
            sb.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is openning .... ");
            Console.WriteLine("Connection is opened .... ");
            string query = @"UPDATE [dbo].[Tbl_Student]
                   SET [StudentName] = @StudentName
                      ,[FatherName]  = @FatherName
                      ,[StudentNo]   = @StudentNo
                      ,[Email]       = @Email
                      ,[DateOfBirth] = @DateOfBirth
                      ,[MobileNo]    = @MobileNo
                      ,[IsDelete]    = 0
                 WHERE [StudentId]   = @StudentId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StudentId", 1); // Assuming you want to update the record with StudentId = 1
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            
            DataRow dr = dt.Rows[0];


            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found with the specified StudentId.");
                return;
            }

            Console.WriteLine(dr["StudentName"]);
            Console.WriteLine(dr["FatherName"]);
            Console.WriteLine(dr["StudentNo"]);
            Console.WriteLine(dr["Email"]);
            Console.WriteLine(dr["DateOfBirth"]);
            Console.WriteLine(dr["MobileNo"]);


            Console.WriteLine("Connection is closing ");
            Console.WriteLine("Connection is closed ");
            connection.Close();
        }

        public void DeleteMethod()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = ".";
            sb.InitialCatalog = "June2026Db"; 
            sb.UserID = "sa";
            sb.Password = "sasa@123";
            sb.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(sb.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Student]
              WHERE StudentNo = 'STU2026001';";
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            string message = result > 0 ? "Deleting Successful" : "Deleting Fail (No record found)";

            connection.Close();
        }

      
    }


};
