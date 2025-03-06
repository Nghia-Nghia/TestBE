using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestBE.Infrastructure.Auth;
using TestBE.Infrastructure.Lifetimes;
using TestBE.Infrastructure.Swagger;

namespace TestBE.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration config
   ) => services.AddSwagger().AddJwtAuth().AddServices();


}
