using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;

namespace Upcoursework.Context.Context.Configuration;
public static class CommentsContextConfiguration
{
    public static void ConfigureComments(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>().ToTable("comments");

        modelBuilder.Entity<Comment>().Property(x => x.Text).IsRequired();
        modelBuilder.Entity<Comment>().Property(x => x.Text).HasMaxLength(1000);

        modelBuilder.Entity<Comment>()
            .HasOne(x => x.Buyer)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.BuyerId);
        modelBuilder.Entity<Comment>()
            .HasOne(x => x.Author)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.AuthorId);
    }
}
