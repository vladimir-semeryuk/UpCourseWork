using Upcoursework.Services.Settings;
using Upcoursework.Services.Logger;
using Upcoursework.Services.Authors;
using Upcoursework.Services.Buyers;

namespace Upcoursework.Api.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddLogSettings()
            .AddAppLogger()
            .AddAuthorService()
            .AddBuyerService();
        return services;
    }
}
