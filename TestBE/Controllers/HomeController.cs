using Microsoft.AspNetCore.Mvc;
using TestBE.Business.HomeService;

namespace TestBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController(IHomeService homeService) : ControllerBase
    {
        [HttpGet("after-install")]
        public async Task<IActionResult> AfterInstall(string shop, string code)
        {
            var url = await homeService.Auth(shop, code);
            return Redirect(url);
        }
    }
}
