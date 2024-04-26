using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;

namespace Upcoursework.Context.Context.Configuration;
public static class AuthorsContextConfiguration
{
    public static void ConfigureAuthors(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().ToTable("authors");
        modelBuilder.Entity<Author>().Property(x => x.DisplayName).IsRequired();
        modelBuilder.Entity<Author>().Property(x => x.DisplayName).HasMaxLength(100);
        
        modelBuilder.Entity<Author>().Property(x=> x.Country).IsRequired();

        modelBuilder.Entity<Author>().Property(x => x.Description).HasMaxLength(5000);

        //modelBuilder.Entity<Author>()
        //    .HasMany(x => x.Comments)
        //    .WithOne(x => x.Author)
        //    .HasForeignKey(x => x.AuthorId);
    }
}