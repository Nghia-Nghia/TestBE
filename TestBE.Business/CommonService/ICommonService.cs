using TestBE.Infrastructure.Lifetimes;
using TestBE.Models.Response.Common;

namespace TestBE.Business.CommonService;

public interface ICommonService : IScopedService
{
    Task<ShopInfoResponse> GetShopData(string domain);
}
