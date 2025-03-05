using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBE.Business.ProductService;

namespace TestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }
    }
}
