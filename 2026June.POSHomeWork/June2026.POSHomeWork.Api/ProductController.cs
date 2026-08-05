using _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Features.Products;
using _2026June.POSHomeWork.June2026.POSHomeWork.Domain.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2026June.POSHomeWork.June2026.POSHomeWork.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var res = _productService.GetAllProducts();

            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var res = _productService.GetProductById(id);
            if (res == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductReqModel product)
        {
            var result = _productService.CreateProduct(product);
            if (result > 0)
            {
                return Ok("Product created successfully.");
            }
            return BadRequest("Failed to create product.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductReqModel product)
        {
            var result = _productService.UpdateProduct(id, product);
            if (result > 0)
            {
                return Ok("Product updated successfully.");
            }
            return BadRequest("Failed to update product.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (result > 0)
            {
                return Ok("Product deleted successfully.");
            }
            return BadRequest("Failed to delete product.");
        }
    }
}
