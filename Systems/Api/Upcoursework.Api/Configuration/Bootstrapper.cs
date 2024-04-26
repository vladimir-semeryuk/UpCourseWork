using Upcoursework.Services.Settings;
using Upcoursework.Services.Logger;
using Upcoursework.Services.Authors;
using Upcoursework.Services.Buyers;
using Upcoursework.Services.Orders;
using Upcoursework.Services.Comments;

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
            .AddBuyerService()
            .AddOrderService()
            .AddCommentService();
        return services;
    }
}
