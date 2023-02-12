using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDB
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<SalesPoint> SalesPoints { get; set; } = null!;
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; } = null!;
        public DbSet<Buyer> Buyers { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<SaleData> SalesData { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProvidedProduct>()
                .HasKey(pp => new { pp.ProductId, pp.SalesPointId });

            modelBuilder.Entity<Sale>()
                .HasOne<Buyer>(s => s.Buyer)
                .WithMany(b => b.SalesIds)
                .HasForeignKey(s => s.BuyerId);

            modelBuilder.Entity<SaleData>()
                .HasKey(sd => new { sd.ProductId, sd.SaleId });
        }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=MarketDB;Username=postgres;Password=PostgresTest");
        }
    }
}
