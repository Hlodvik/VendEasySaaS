using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vend.Models;

public partial class VendContext : DbContext
{
    public VendContext()
    {
    }

    public VendContext(DbContextOptions<VendContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artwork> Artworks { get; set; }

    public virtual DbSet<BillingTransaction> BillingTransactions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Listing> Listings { get; set; }

    public virtual DbSet<MarketplaceIntegration> MarketplaceIntegrations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Server=tcp:vendeasy.database.windows.net,1433;Initial Catalog=vend;User ID=master;Password=password1!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artwork>(entity =>
        {
            entity.HasKey(e => e.ArtworkId).HasName("PK__Artworks__D073AE9BCBC60B0F");

            entity.ToTable("Artwork");

            entity.Property(e => e.Genre).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Tenant).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Artworks__Tenant__6D0D32F4");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Artworks__Vendor__6E01572D");
        });

        modelBuilder.Entity<BillingTransaction>(entity =>
        {
            entity.HasKey(e => e.BillingTransactionId).HasName("PK__BillingT__695FC1CC8D763080");

            entity.ToTable("BillingTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Currency).HasMaxLength(10);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Tenant).WithMany(p => p.BillingTransactions)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BillingTr__Tenan__04E4BC85");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D82DCB2005");

            entity.ToTable("Customer");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Customers)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__Tenan__693CA210");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__UserI__6A30C649");
        });

        modelBuilder.Entity<Listing>(entity =>
        {
            entity.HasKey(e => e.ListingId).HasName("PK__Listings__BF3EBED05CC112AE");

            entity.ToTable("Listing");

            entity.Property(e => e.ExternalListingId).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Artwork).WithMany(p => p.Listings)
                .HasForeignKey(d => d.ArtworkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Listings__Artwor__7D439ABD");

            entity.HasOne(d => d.Integration).WithMany(p => p.Listings)
                .HasForeignKey(d => d.IntegrationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Listings__Integr__7E37BEF6");
        });

        modelBuilder.Entity<MarketplaceIntegration>(entity =>
        {
            entity.HasKey(e => e.IntegrationId).HasName("PK__Marketpl__D8956835C3B09FAE");

            entity.ToTable("MarketplaceIntegration");

            entity.Property(e => e.Platform).HasMaxLength(100);
            entity.Property(e => e.SyncStatus).HasMaxLength(50);

            entity.HasOne(d => d.Tenant).WithMany(p => p.MarketplaceIntegrations)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marketpla__Tenan__797309D9");

            entity.HasOne(d => d.Vendor).WithMany(p => p.MarketplaceIntegrations)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Marketpla__Vendo__7A672E12");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF2931AC94");

            entity.ToTable("Order");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.ShippingStatus).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Customer__72C60C4A");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__TenantId__71D1E811");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__57ED0681F3089BC2");

            entity.ToTable("OrderItem");

            entity.Property(e => e.PriceAtPurchase).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Artwork).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ArtworkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Artwo__76969D2E");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__75A278F5");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.SubscriptionId).HasName("PK__Subscrip__9A2B249DC766C91C");

            entity.ToTable("Subscription");

            entity.Property(e => e.RenewalDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SubPlan).HasMaxLength(100);

            entity.HasOne(d => d.Tenant).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Subscript__Tenan__01142BA1");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__Tenants__2E9B47E1DEEC5396");

            entity.ToTable("Tenant");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Domain).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.PrimaryVendor).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.PrimaryVendorId)
                .HasConstraintName("FK_Tenants_PrimaryVendor");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CF9C944BF");

            entity.ToTable("User");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Tenant).WithMany(p => p.Users)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__TenantId__619B8048");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__FC8618F3D084C5F7");

            entity.ToTable("Vendor");

            entity.Property(e => e.DisplayName).HasMaxLength(200);

            entity.HasOne(d => d.Tenant).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vendors__TenantI__656C112C");

            entity.HasOne(d => d.User).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vendors__UserId__66603565");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
