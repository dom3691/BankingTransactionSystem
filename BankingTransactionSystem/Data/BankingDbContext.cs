using BankingTransactionSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingTransactionSystem.Data
{
    public class BankingDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerId);
        }
    }
}
