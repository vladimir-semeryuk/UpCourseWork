using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Context;
using Upcoursework.Context.Settings;

namespace Upcoursework.Context.Factories;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
{
    public MainDbContext CreateDbContext(string[] args)
    {
        var provider = (args?[0] ?? $"{DbType.PgSql}").ToLower();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.context.json"), false)
            .Build();

        var connectionString = configuration.GetConnectionString(provider)!;

        DbType dbType;
        if (provider.Equals($"{DbType.MSSQL}".ToLower()))
            dbType = DbType.MSSQL;
        if (provider.Equals($"{DbType.PgSql}".ToLower()))
            dbType = DbType.PgSql;
        else
            throw new Exception($"Unsupported provider: {provider}");

        var options = DbContextOptionsFactory.Create(connectionString, dbType, false);
        var factory = new DbContextFactory(options);
        var context = factory.Create();

        return context;
    }
}
