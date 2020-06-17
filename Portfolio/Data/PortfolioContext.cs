using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioContext : IdentityDbContext<IdentityUser>
    {
        public PortfolioContext()
        {
        }

        public PortfolioContext (DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PortfolioContext-c573351a-817a-461e-8c63-0fde450fc20e;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Blog> Blog { get; set; }

        public DbSet<Comment> Comment { get; set; }
    }
}
