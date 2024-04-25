using Microsoft.EntityFrameworkCore;
using Upcoursework.Context.Context;

namespace Upcoursework.Context.Factories;

public class DbContextFactory
{
    private readonly DbContextOptions<MainDbContext> options;

    public DbContextFactory(DbContextOptions<MainDbContext> options)
    {
        this.options = options;
    }

    public MainDbContext Create()
    {
        return new MainDbContext(options);
    }
}
