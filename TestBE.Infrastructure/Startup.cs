using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration config
   ) => services.AddServices();


}
