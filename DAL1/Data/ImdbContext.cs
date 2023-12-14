using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL1;

public partial class ImdbContext : DbContext
{
    public ImdbContext()
    {
    }

    public ImdbContext(DbContextOptions<ImdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderToy> OrderToys { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Toy> Toys { get; set; }

    public virtual DbSet<ToyCategory> ToyCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=ToyShop;Integrated Security=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B84C692799");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFE50BBDDD");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Orders_Customers");
        });

        modelBuilder.Entity<OrderToy>(entity =>
        {
            entity.HasKey(e => e.OrderToyId).HasName("PK__OrderToy__EEA5D5282EEE44FB");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderToys)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderToys_Orders");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId).HasName("PK__Shop__67C556297EA3F4E5");

            entity.HasOne(d => d.Storage).WithMany(p => p.Shops)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Shop_Storage");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.StorageId).HasName("PK__Storage__8A247E37071421FF");

            entity.HasOne(d => d.Toy).WithMany(p => p.Storages)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Storage_Toy");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE66694847A2529");
        });

        modelBuilder.Entity<Toy>(entity =>
        {
            entity.HasKey(e => e.ToyId).HasName("PK__Toy__187746B67276F3ED");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Toys)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Toy_ToyCategories");

            entity.HasOne(d => d.SupplierNavigation).WithMany(p => p.Toys)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Toy_Suppliers");
        });

        modelBuilder.Entity<ToyCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ToyCateg__19093A2B28C12DB9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
