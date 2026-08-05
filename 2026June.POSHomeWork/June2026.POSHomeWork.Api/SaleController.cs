using _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Features.Sales;
using _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2026June.POSHomeWork.June2026.POSHomeWork.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            var res = _saleService.GetAllSales();
            return Ok(res);
        }

        [HttpGet("{voucherNo}")]
        public IActionResult GetSaleByVoucherNo(string voucherNo)
        {
            var res = _saleService.GetSaleByVoucherNo(voucherNo);
            if (res == null)
            {
                return NotFound($"Sale voucher {voucherNo} not found.");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateSale([FromBody] SaleReqModel request)
        {
            try
            {
                var voucherNo = _saleService.CreateSale(request);
                return Ok(new { Message = "Sale created successfully.", VoucherNo = voucherNo });
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create sale: {ex.Message}");
            }
        }
    }
}
