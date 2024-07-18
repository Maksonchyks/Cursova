using Cursova.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<SalesDeal> SalesDeals { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SalesDeal>()
            .HasOne(sd => sd.Customer)
            .WithMany(c => c.SalesDeals)
            .HasForeignKey(sd => sd.FrCustomerId);

        modelBuilder.Entity<SalesDeal>()
            .HasOne(sd => sd.Stock)
            .WithOne(st => st.SalesDeal)
            .HasForeignKey<SalesDeal>(sd => sd.FrStockId);

        modelBuilder.Entity<SalesDeal>()
            .HasOne(sd => sd.Supplier)
            .WithMany(s => s.SalesDeals)
            .HasForeignKey(sd => sd.FrSupplierId);

        modelBuilder.Entity<Stock>()
            .HasOne(st => st.Supplier)
            .WithMany(s => s.Stocks)
            .HasForeignKey(st => st.FrSupplierId);



        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
        
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.CustomerId);

        modelBuilder.Entity<SalesDeal>()
            .HasKey(sd => sd.DealId);

        modelBuilder.Entity<Stock>()
            .HasKey(st => st.StockId);

        modelBuilder.Entity<Supplier>()
            .HasKey(s => s.SupplierId);
    }
}

