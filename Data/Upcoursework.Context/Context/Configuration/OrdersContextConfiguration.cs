using Microsoft.EntityFrameworkCore;
using Upcoursework.Context.Entities;

namespace Upcoursework.Context.Context.Configuration;
public static class OrdersContextConfiguration
{
    public static void ConfigureOrders(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("orders");
        //modelBuilder.Entity<Order>().Property(x => x.Subject).IsRequired();
        modelBuilder.Entity<Order>().Property(x => x.Budget).IsRequired();
        modelBuilder.Entity<Order>().Property(x => x.Description).HasMaxLength(10000);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Author)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AuthorId);
    }
}
