using TestBE.Infrastructure.Database.Entities;
using TestBE.Infrastructure.Lifetimes;
using TestBE.Models.Request.Products;

namespace TestBE.Business.ProductService;

public interface IProductService : IScopedService
{
    Task<List<Product>> GetAll(OptionFilterProduct option);
}
