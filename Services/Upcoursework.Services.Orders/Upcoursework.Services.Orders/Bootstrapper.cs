using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Services.Orders.Orders;

namespace Upcoursework.Services.Orders;
public static class Bootstrapper
{
    public static IServiceCollection AddOrderService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IOrderService, OrderService>();
    }
}
