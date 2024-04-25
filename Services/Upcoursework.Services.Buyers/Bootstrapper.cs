using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Services.Buyers.Buyers;

namespace Upcoursework.Services.Buyers;
public static class Bootstrapper
{
    public static IServiceCollection AddBuyerService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IBuyerService, BuyerService>();
    }
}
