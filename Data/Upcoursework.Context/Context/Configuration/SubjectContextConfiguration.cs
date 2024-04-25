using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.Context.Context.Configuration;
public static class SubjectContextConfiguration
{
    public static void ConfigureSubjects(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subject>().ToTable("subjects");
        modelBuilder.Entity<Subject>().Property(x => x.Title).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Subject>().Property(s => s.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Subject>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Subjects)
            .UsingEntity(t => t.ToTable("subjects_authors"));

        modelBuilder.Entity<Subject>()
            .HasMany(x => x.Orders)
            .WithOne(x => x.Subject);
    }
}
