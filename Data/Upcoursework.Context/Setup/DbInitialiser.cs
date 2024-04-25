using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Upcoursework.Context.Context;

namespace Upcoursework.Context.Setup;

public static class DbInitialiser
{
    public static void Execute(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetService<IServiceScopeFactory>()?.CreateScope();
        ArgumentNullException.ThrowIfNull(scope);

        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>();
        using var context = dbContextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}
