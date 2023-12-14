using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class ImdbContext : DbContext
{
    public ImdbContext()
    {
    }

    public ImdbContext(DbContextOptions<ImdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderProduct> TbOrderProducts { get; set; }

    public virtual DbSet<TbPerson> TbPeople { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbProductHistory> TbProductHistories { get; set; }

    public virtual DbSet<TbProvider> TbProviders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-BPDBP75F;Initial Catalog=programming;Integrated Security=True;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Orders");

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Person).WithMany(p => p.TbOrders).HasConstraintName("FK_Order_Person");
        });

        modelBuilder.Entity<TbOrderProduct>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_tb_order_product_1");

            entity.HasOne(d => d.Order).WithMany(p => p.TbOrderProducts).HasConstraintName("FK_tb_order_product_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.TbOrderProducts).HasConstraintName("FK_Order_product_Product");
        });

        modelBuilder.Entity<TbPerson>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK_Person");

            entity.Property(e => e.PersonId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product");

            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.ProviderNameNavigation).WithMany(p => p.TbProducts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Product_Company1");
        });

        modelBuilder.Entity<TbProductHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK_ProductHistory");

            entity.Property(e => e.HistoryId).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.TbProductHistories).HasConstraintName("FK_ProductHistory_Order");
        });

        modelBuilder.Entity<TbProvider>(entity =>
        {
            entity.HasKey(e => e.ProviderName).HasName("PK_Company");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
