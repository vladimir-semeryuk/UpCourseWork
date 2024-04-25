using Microsoft.Extensions.DependencyInjection;
using Upcoursework.Services.Logger.Logger;

namespace Upcoursework.Services.Logger;
public static class Bootstrapper
{
    public static IServiceCollection AddAppLogger(this IServiceCollection services)
    {
        return services
            .AddSingleton<IAppLogger, AppLogger>();
    }
}
