namespace _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Product
{
    public class ProductReqModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQty { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
