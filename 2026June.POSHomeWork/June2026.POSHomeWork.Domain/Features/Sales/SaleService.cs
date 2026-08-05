using _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Sales;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Features.Sales
{
    public class SaleService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "June2026Db", // database name
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public List<SaleResModel> GetAllSales()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();

            string saleQuery = "SELECT * FROM [dbo].[Tbl_Sale];";
            List<SaleResModel> sales = db.Query<SaleResModel>(saleQuery).ToList();

            foreach (var sale in sales)
            {
                string detailQuery = "SELECT * FROM [dbo].[Tbl_SaleDetail] WHERE VoucherNo = @VoucherNo;";
                sale.SaleDetails = db.Query<SaleDetailReqModel>(detailQuery, new { sale.VoucherNo }).ToList();
            }

            db.Close();
            return sales;
        }

        public SaleResModel? GetSaleByVoucherNo(string voucherNo)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();

            string saleQuery = "SELECT * FROM [dbo].[Tbl_Sale] WHERE VoucherNo = @voucherNo;";
            SaleResModel? sale = db.QueryFirstOrDefault<SaleResModel>(saleQuery, new { voucherNo });

            if (sale != null)
            {
                string detailQuery = "SELECT * FROM [dbo].[Tbl_SaleDetail] WHERE VoucherNo = @voucherNo;";
                sale.SaleDetails = db.Query<SaleDetailReqModel>(detailQuery, new { voucherNo }).ToList();
            }

            db.Close();
            return sale;
        }

        public string CreateSale(SaleReqModel request)
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();

            using var transaction = db.BeginTransaction();

            try
            {
                if (string.IsNullOrWhiteSpace(request.VoucherNo))
                {
                    request.VoucherNo = $"VCH-{DateTime.Now:yyyyMMddHHmmss}";
                }

                string insertSaleQuery = @"INSERT INTO [dbo].[Tbl_Sale] 
                                          (VoucherNo, SaleDate, TotalAmount, Tax, Discount, GrandTotal) 
                                          VALUES 
                                          (@VoucherNo, @SaleDate, @TotalAmount, @Tax, @Discount, @GrandTotal);";

                db.Execute(insertSaleQuery, request, transaction);

                foreach (var item in request.SaleDetails)
                {
                    item.VoucherNo = request.VoucherNo;

                    string insertDetailQuery = @"INSERT INTO [dbo].[Tbl_SaleDetail] 
                                                (VoucherNo, ProductID, Quantity, Price, TotalAmount) 
                                                VALUES 
                                                (@VoucherNo, @ProductID, @Quantity, @Price, @TotalAmount);";

                    db.Execute(insertDetailQuery, item, transaction);

                    // Reduce Stock Quantity in Tbl_Product
                    string updateStockQuery = @"UPDATE [dbo].[Tbl_Product] 
                                                SET StockQty = StockQty - @Quantity 
                                                WHERE ProductID = @ProductID;";

                    db.Execute(updateStockQuery, new { item.Quantity, item.ProductID }, transaction);
                }

                transaction.Commit();
                db.Close();

                return request.VoucherNo;
            }
            catch (Exception)
            {
                transaction.Rollback();
                db.Close();
                throw;
            }
        }
    }
}
