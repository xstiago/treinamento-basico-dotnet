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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NaturalPerson>().ToTable("NaturalPerson");
            modelBuilder.Entity<NaturalPerson>().HasIndex(h => h.CPF).IsUnique();

            modelBuilder.Entity<LegalPerson>().ToTable("LegalPerson");
            modelBuilder.Entity<LegalPerson>().HasIndex(h => h.CNPJ).IsUnique();
        }
    }
}
