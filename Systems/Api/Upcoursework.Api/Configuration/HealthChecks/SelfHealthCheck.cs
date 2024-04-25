using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace Upcoursework.Api.Configuration.HealthChecks;

public class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var assembly = Assembly.Load("Upcoursework.Api");
        var versionNumber = assembly.GetName().Version;

        return Task.FromResult(HealthCheckResult.Healthy($"Build {versionNumber}"));
    }
}