using Microsoft.EntityFrameworkCore;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>().HasIndex(h => h.Name).IsUnique();
        }
    }
}
