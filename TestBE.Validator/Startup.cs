using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TestBE.Validator;

public static class Startup
{
    public static IServiceCollection AddValidatorModel(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()).AddFluentValidationAutoValidation();
    }
}
