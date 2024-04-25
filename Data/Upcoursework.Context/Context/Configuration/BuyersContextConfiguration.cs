using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;

namespace Upcoursework.Context.Context.Configuration;
public static class BuyersContextConfiguration
{
    public static void ConfigureBuyers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Buyer>().ToTable("buyers");
        modelBuilder.Entity<Buyer>().Property(x => x.DisplayName).IsRequired();
        modelBuilder.Entity<Buyer>().Property(x => x.DisplayName).HasMaxLength(100);

        modelBuilder.Entity<Buyer>().Property(x => x.Country).IsRequired();
    }
}
