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
    }
}
