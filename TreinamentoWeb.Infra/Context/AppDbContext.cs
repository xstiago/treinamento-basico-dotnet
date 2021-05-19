using Microsoft.EntityFrameworkCore;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NaturalPerson> NaturalPerson { get; set; }
        public DbSet<LegalPerson> LegalPerson { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NaturalPerson>().ToTable("NaturalPerson");
            modelBuilder.Entity<NaturalPerson>().HasIndex(h => h.CPF).IsUnique();

            modelBuilder.Entity<LegalPerson>().ToTable("LegalPerson");
            modelBuilder.Entity<LegalPerson>().HasIndex(h => h.CNPJ).IsUnique();

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().HasIndex(h => h.Description).IsUnique();
            
            modelBuilder.Entity<Order>().ToTable("Order");
            //modelBuilder.Entity<Order>().HasIndex(h => h.ID).IsUnique();
        }
    }
}
