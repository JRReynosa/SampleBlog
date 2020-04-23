using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext()
        {
        }

        public PortfolioContext (DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio.Models.Blog> Blog { get; set; }

        public DbSet<Portfolio.Models.Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PortfolioContext-c573351a-817a-461e-8c63-0fde450fc20e;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Portfolio.Models.Contact> Contact { get; set; }
    }
}
