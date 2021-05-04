using Microsoft.EntityFrameworkCore;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<NaturalPerson> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NaturalPerson>().ToTable("Customer");
            modelBuilder.Entity<NaturalPerson>().HasIndex(h => h.Name).IsUnique();
        }
    }
}
