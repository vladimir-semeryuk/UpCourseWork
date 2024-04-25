using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Upcoursework.Api.Configuration.HealthChecks;
using Upcoursework.Common.HealthChecks;

namespace Upcoursework.Api.Configuration;

public static class HealthCheckConfiguration
{
    public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<SelfHealthCheck>("Upcoursework.Api");

        return services;
    }

    public static void UseAppHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");

        app.MapHealthChecks("/health/detail", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckHelper.WriteHealthCheckResponse,
            AllowCachingResponses = false
        });
    }
}