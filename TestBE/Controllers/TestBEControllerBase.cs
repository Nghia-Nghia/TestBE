using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestBE.Models.Response.Common;

namespace TestBE.Controllers
{
    public class TestBEControllerBase : ControllerBase
    {
        protected static JsonResult SuccessResponse<T>(T result)
        {
            return new JsonResult(
                new BaseResponse<T> { StatusCode = HttpStatusCode.OK, Result = result }
            );
        }

        protected static JsonResult SuccessResponse<T>(HttpStatusCode statusCode, T result)
        {
            return new JsonResult(
                new BaseResponse<T> { StatusCode = statusCode, Result = result }
            );
        }
    }
}
