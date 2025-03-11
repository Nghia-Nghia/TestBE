using Microsoft.Extensions.DependencyInjection;
using TestBE.Business.Resilience;

namespace TestBE.Business
{
    public static class Startup
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        => services.AddResilience();
    }
}
