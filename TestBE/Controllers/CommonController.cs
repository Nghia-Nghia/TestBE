using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestBE.Business.CommonService;

namespace TestBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ICommonService commonService) : TestBEControllerBase
    {
        [HttpGet("shop-info")]
        [AllowAnonymous]
        public async Task<IActionResult> ShopInformation(string domain)
        {
            var response = await commonService.GetShopData(domain);
            return SuccessResponse(response);
        }
    }
}
