using _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Product;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Features.Products
{
    public class ProductService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".", 
            InitialCatalog = "June2026Db", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public List<ProductReqModel> GetAllProducts()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            List<ProductReqModel> lst = db.Query<ProductReqModel>("SELECT * FROM [dbo].[Tbl_Product] WHERE IsDelete = 0 OR IsDelete IS NULL;").ToList();

            foreach (var item in lst)
            {
                Console.WriteLine($"Id: {item.ProductID}, Name: {item.ProductName}");
            }
            db.Close();

            return lst;
        }

        public ProductReqModel? GetProductById(int id)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            ProductReqModel? item = db.QueryFirstOrDefault<ProductReqModel>(
                "SELECT * FROM [dbo].[Tbl_Product] WHERE ProductID = @id AND (IsDelete = 0 OR IsDelete IS NULL);",
                new { id }
            );
            db.Close();

            return item;
        }

        public int CreateProduct(ProductReqModel product)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Product] 
                            (ProductName, Price, StockQty, IsDelete) 
                            VALUES 
                            (@ProductName, @Price, @StockQty, 0);";
            int result = db.Execute(query, product);
            db.Close();

            return result;
        }

        public int UpdateProduct(int id, ProductReqModel product)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            product.ProductID = id;
            string query = @"UPDATE [dbo].[Tbl_Product]
                            SET ProductName = @ProductName,
                                Price = @Price,
                                StockQty = @StockQty
                            WHERE ProductID = @ProductID;";
            int result = db.Execute(query, product);
            db.Close();

            return result;
        }

        public int DeleteProduct(int id)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            string query = @"UPDATE [dbo].[Tbl_Product] 
                            SET IsDelete = 1 
                            WHERE ProductID = @id;";
            int result = db.Execute(query, new { id });
            db.Close();

            return result;
        }
    }
}
