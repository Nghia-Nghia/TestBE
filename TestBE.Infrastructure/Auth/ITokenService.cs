using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Infrastructure.Auth;

public interface ITokenService : IScopedService
{
    string GenerateJwt(string domain, Guid id);
}
