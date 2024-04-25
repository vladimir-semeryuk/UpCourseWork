using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upcoursework.Context.Settings;
using Upcoursework.Context.Context;
using Upcoursework.Context.Factories;
using Upcoursework.Common.Settings;

namespace Upcoursework.Context;
public static class Bootstrapper
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Common.Settings.Settings.Load<DbSettings>("Database", configuration);
        services.AddSingleton(settings);

        var dbInitOptionsDelegate = DbContextOptionsFactory.Configure(settings.ConnectionString, settings.Type, true);

        services.AddDbContextFactory<MainDbContext>(dbInitOptionsDelegate);

        return services;
    }
}
