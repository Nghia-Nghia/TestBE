using TestBE.Models.Dtos;

namespace TestBE.Models.Response.Common;

public record ShopInfoResponse(ShopDto Shop, string Token);
