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
                  ,[DateOfBirth]
                  ,[MobileNo]
                  ,[IsDelete]
              FROM [dbo].[Tbl_Student] WHERE IsDelete='0' ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            //DataTable dt = new DataTable();
            //dataAdapter.Fill(dt);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read()) {
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
                  ,[DateOfBirth]
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

            foreach (DataRow dr in dt.Rows) {
                Console.WriteLine(dr["StudentName"]);
                Console.WriteLine(dr["FatherName"]);
                Console.WriteLine(dr["StudentNo"]);
                Console.WriteLine(dr["Email"]);
                Console.WriteLine(dr["DateOfBirth"]);
                Console.WriteLine(dr["MobileNo"]);
            }
            Console.WriteLine("Connection Closed.......");
        }
    
    }
}
