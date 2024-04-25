using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Entities.Tags;

namespace Upcoursework.Context.Context.Configuration;
public static class SkillsContextConfiguration
{
    public static void ConfigureSkills(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skill>().ToTable("skills");
        modelBuilder.Entity<Skill>().Property(x => x.Title).IsRequired().HasMaxLength(100);

        modelBuilder.Entity<Skill>()
            .HasMany(x => x.Authors)
            .WithMany(x => x.Skills)
            .UsingEntity(t => t.ToTable("skills_authors"));

        modelBuilder.Entity<Skill>()
            .HasMany(x => x.Orders)
            .WithMany(x => x.SkillsRequired)
            .UsingEntity(t => t.ToTable("skills_orders"));
    }
}

