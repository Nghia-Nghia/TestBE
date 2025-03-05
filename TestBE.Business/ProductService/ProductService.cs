using Microsoft.EntityFrameworkCore;
using TestBE.Infrastructure.Database;
using TestBE.Infrastructure.Database.Entities;

namespace TestBE.Business.ProductService;

public class ProductService(AppDbContext dbContext) : IProductService
{
    public Task<List<Product>> GetAll()
    {
        return dbContext.Products.ToListAsync();
    }
}
