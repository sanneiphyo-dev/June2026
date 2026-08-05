namespace _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Sales
{
    public class SaleResModel
    {
        public int SaleID { get; set; }
        public string VoucherNo { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public List<SaleDetailReqModel> SaleDetails { get; set; } = new List<SaleDetailReqModel>();
    }
}
