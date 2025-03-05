using TestBE.Infrastructure.Database.Entities;
using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Business.ProductService;

public interface IProductService : IScopedService
{
    Task<List<Product>> GetAll();
}
