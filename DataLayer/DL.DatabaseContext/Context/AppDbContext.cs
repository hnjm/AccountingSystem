using Microsoft.EntityFrameworkCore;
using DL.DomainModels.Entities;
using DL.Interfaces.DatabaseContext;
using Module.Enums;
using System;

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
            modelBuilder.Entity<Operation>().HasData(
                new Operation { Id = 1, Amount = 1000, TotalAmount = 1000, Description = "Initial Debit", Type = OperationType.Debit, CreateDate = DateTime.Now },
                new Operation { Id = 2, Amount = 100, TotalAmount = 900, Description = "Initial Credit", Type = OperationType.Credit, CreateDate = DateTime.Now }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
