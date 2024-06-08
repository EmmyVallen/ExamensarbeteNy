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

        public DbSet<Bevakning> Bevakningar { get; set; }
        public DbSet<Kundkorg> Kundkorgar { get; set; }
        public DbSet<ChildKategori> ChildKategorier { get; set; }

     
    }
}
