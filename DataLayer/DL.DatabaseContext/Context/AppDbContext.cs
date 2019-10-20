using Microsoft.EntityFrameworkCore;
using DL.DomainModels.Entities;
using DL.Interfaces.DatabaseContext;

namespace DL.DatabaseContext.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
