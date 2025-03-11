using Microsoft.AspNetCore.Mvc;
using TestBE.Business.ProductService;
using TestBE.Models.Request.Products;

namespace TestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service) : TestBEControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OptionFilterProduct option)
        {
            var data = await service.GetAll(option);
            return SuccessResponse(data);
        }
        [HttpGet("get-from-shopify")]
        public async Task<IActionResult> GetAllFromShopify([FromQuery] string domain, string? cursor, int pageSize)
        {
            var data = await service.GetProductsAsync(domain,cursor,pageSize);
            return SuccessResponse(data);
        }
    }
}
