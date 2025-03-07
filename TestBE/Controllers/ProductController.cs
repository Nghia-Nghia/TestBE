using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBE.Business.ProductService;

namespace TestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service) : TestBEControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAll();
            return Ok(data);
        }
    }
}
