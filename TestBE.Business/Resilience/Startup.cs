using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace TestBE.Business.Resilience
{
    public static class Startup
    {
        public static IServiceCollection AddResilience(this IServiceCollection services)
        {
            services.AddHttpClient("ResilientHttpClient")
            .AddStandardResilienceHandler(options =>
            {
                options.Retry.MaxRetryAttempts = 3;
                options.Retry.Delay = TimeSpan.FromMilliseconds(500);
                options.Retry.BackoffType = DelayBackoffType.Exponential;

                options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(30);
                options.CircuitBreaker.MinimumThroughput = 10;
                options.CircuitBreaker.FailureRatio = 0.5;
                options.CircuitBreaker.BreakDuration = TimeSpan.FromSeconds(10);
                options.AttemptTimeout.Timeout = TimeSpan.FromSeconds(10);


            });
            return services;
        }
    }
}
