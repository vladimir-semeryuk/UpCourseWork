using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Services.Authors.Authors;

namespace Upcoursework.Services.Authors;
public static class Bootstrapper
{
    public static IServiceCollection AddAuthorService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IAuthorService, AuthorService>();
    }
}