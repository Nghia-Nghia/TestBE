
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestBE.Infrastructure.Database;

public static class Extensions
{
    public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration["DatabaseSettings:ConnectionString"],
                builder =>
                    builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName))
                    ;
        });
    }
}