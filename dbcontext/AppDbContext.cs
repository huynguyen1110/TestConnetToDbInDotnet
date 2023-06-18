using Microsoft.EntityFrameworkCore;
using System.Numerics;
using WebApplication1.models;

namespace WebApplication1.dbcontext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreSupplier>()
                .HasKey(ss => new { ss.StoreId, ss.SupplierId });

            modelBuilder.Entity<StoreSupplier>()
                .HasOne(ss => ss.Store)
                .WithMany(ss => ss.StoreSuppliers)
                .HasForeignKey(ss => ss.StoreId);

            modelBuilder.Entity<StoreSupplier>()
                .HasOne(ss => ss.Supplier)
                .WithMany(ss => ss.StoreSuppliers)
                .HasForeignKey(ss => ss.SupplierId);

            modelBuilder.Entity<StoreSupplier>()
                .Property(ss => ss.IntimacyLevel)
                .IsRequired();
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StoreSupplier> SuppliersSupplier { get; set; }
    }
}
