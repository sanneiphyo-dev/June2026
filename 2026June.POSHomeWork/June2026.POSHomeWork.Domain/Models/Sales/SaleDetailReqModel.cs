namespace _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Sales
{
    public class SaleDetailReqModel
    {
        public int SaleDetailID { get; set; }
        public string VoucherNo { get; set; } = string.Empty;
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
