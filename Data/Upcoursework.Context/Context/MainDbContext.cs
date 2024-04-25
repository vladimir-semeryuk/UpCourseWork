using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcoursework.Context.Context.Configuration;
using Upcoursework.Context.Entities;
using Upcoursework.Context.Entities.Tags;
using Upcoursework.Context.Entities.User;

namespace Upcoursework.Context.Context
{
    public class MainDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBuyers();
            modelBuilder.ConfigureComments();
            modelBuilder.ConfigureOrders();
            modelBuilder.ConfigureSkills();
            modelBuilder.ConfigureSubjects();
            modelBuilder.ConfigureAuthors();
            modelBuilder.ConfigureUsers();
        }
    }
}
