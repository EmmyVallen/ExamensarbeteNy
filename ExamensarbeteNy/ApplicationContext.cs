using System.Collections.Generic;
using System.Reflection.Emit;
using ExamensarbeteNy.Models;
using Microsoft.EntityFrameworkCore;


namespace ExamensarbeteNy
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        // Lägg till DbSet för varje modellklass här
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<Produkt> Produkter { get; set; }
        public DbSet<Användare> Användare { get; set; }
        public DbSet<Bevakning> Bevakningar { get; set; }
        public DbSet<Kundkorg> Kundkorgar { get; set; }
        public DbSet<ChildKategori> ChildKategorier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfigurera relationen mellan Användare och Kundkorg
            modelBuilder.Entity<Användare>()
                .HasOne(a => a.Kundkorg) // Användare har en Kundkorg
                .WithOne(k => k.Användare) // Kundkorg har en Användare
                .HasForeignKey<Kundkorg>(k => k.AnvändarId); // Ange den främmande nyckeln

        }
    }
}
