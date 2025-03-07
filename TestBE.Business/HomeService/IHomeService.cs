using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Business.HomeService;

public interface IHomeService : IScopedService
{
    Task<string> Auth(string domain, string code);
}
