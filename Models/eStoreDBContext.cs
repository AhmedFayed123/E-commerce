using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eStore.Models;

public partial class eStoreDBContext : DbContext
{
    public eStoreDBContext()
    {
    }

    public eStoreDBContext(DbContextOptions<eStoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CompanyInformation> CompanyInformations { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderPayment> OrderPayments { get; set; }

    public virtual DbSet<PaymentMethodsList> PaymentMethodsLists { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<StatusList> StatusLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QAEE8VR\\SQLEXPRESS01;Database=eStore;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasIndex(e => e.Id, "UQ_Brands_Id ").IsUnique();

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(150)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cart");

            entity.Property(e => e.UserId).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Carts_Products");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(150)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<CompanyInformation>(entity =>
        {
            entity.ToTable("CompanyInformation");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Logo).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.TimeZone).HasMaxLength(50);
            entity.Property(e => e.WebSite).HasMaxLength(100);

            entity.HasOne(d => d.DefaultCurrency).WithMany(p => p.CompanyInformations)
                .HasForeignKey(d => d.DefaultCurrencyId)
                .HasConstraintName("FK_CompanyInformation_Currencies");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.ArabicName).HasMaxLength(50);
            entity.Property(e => e.CurrencyName).HasMaxLength(50);
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.AppartNo).HasMaxLength(4);
            entity.Property(e => e.BuildingNo).HasMaxLength(10);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Floor).HasMaxLength(10);
            entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Mobile)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Pwd)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("PWD");
            entity.Property(e => e.Street).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsNotActive).HasDefaultValue(false);
            entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK_Orders_StatusList");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.ItemPrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.ItemPriceAfterDiscount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Quantity).HasDefaultValue(1);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetails_OrderDetails");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<OrderPayment>(entity =>
        {
            entity.Property(e => e.Commission).HasDefaultValue(0.0);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderPayments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderPayments_Orders");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.OrderPayments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK_OrderPayments_PaymentMethodsList");
        });

        modelBuilder.Entity<PaymentMethodsList>(entity =>
        {
            entity.ToTable("PaymentMethodsList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Commission).HasDefaultValue(0.0);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("ChangeLastModifiedDateAfterUpdate"));

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentPrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.IsNotActive).HasDefaultValue(false);
            entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ShortDescription).HasMaxLength(200);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductImages_Products");
        });

        modelBuilder.Entity<StatusList>(entity =>
        {
            entity.ToTable("StatusList");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
