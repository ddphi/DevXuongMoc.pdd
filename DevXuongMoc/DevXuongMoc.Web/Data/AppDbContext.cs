using System;
using System.Collections.Generic;
using DevXuongMoc.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevXuongMoc.Web.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactNote> ContactNotes { get; set; }

    public virtual DbSet<ContactRequest> ContactRequests { get; set; }

    public virtual DbSet<ContentBlock> ContentBlocks { get; set; }

    public virtual DbSet<EmailOutbox> EmailOutboxes { get; set; }

    public virtual DbSet<MediaFile> MediaFiles { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductVariant> ProductVariants { get; set; }

    public virtual DbSet<SiteSetting> SiteSettings { get; set; }

    public virtual DbSet<SlugHistory> SlugHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-14HSE16\\SQLEXPRESS;Database=DevXuongMoc_Pro;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ARTICLE__3214EC07777B9911");

            entity.ToTable("ARTICLE");

            entity.HasIndex(e => e.Slug, "UX_ARTICLE_Slug").IsUnique();

            entity.Property(e => e.AuthorId).HasMaxLength(450);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Slug).HasMaxLength(220);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Author).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__ARTICLE__AuthorI__30F848ED");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AUDIT_LO__3214EC07972A24F0");

            entity.ToTable("AUDIT_LOG");

            entity.HasIndex(e => e.CreatedAt, "IX_AUDIT_LOG_CreatedAt").IsDescending();

            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EntityName).HasMaxLength(100);
            entity.Property(e => e.Summary).HasMaxLength(1000);
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__AUDIT_LOG__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BANNER__3214EC076AC85D44");

            entity.ToTable("BANNER");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LinkUrl).HasMaxLength(500);
            entity.Property(e => e.Placement).HasDefaultValue((byte)1);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORY__3214EC07398CEE3F");

            entity.ToTable("CATEGORY");

            entity.HasIndex(e => e.Name, "UQ__CATEGORY__737584F62CD8A325").IsUnique();

            entity.HasIndex(e => e.Slug, "UQ__CATEGORY__BC7B5FB66D6EE47D").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IconPath).HasMaxLength(260);
            entity.Property(e => e.IsVisible).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Slug).HasMaxLength(120);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ContactNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CONTACT___3214EC07972A4D97");

            entity.ToTable("CONTACT_NOTE");

            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsSystem).HasDefaultValue(false);

            entity.HasOne(d => d.ContactRequest).WithMany(p => p.ContactNotes)
                .HasForeignKey(d => d.ContactRequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__CONTACT_N__Conta__4AB81AF0");
        });

        modelBuilder.Entity<ContactRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CONTACT___3214EC0709BBF921");

            entity.ToTable("CONTACT_REQUEST");

            entity.Property(e => e.AssignedToId).HasMaxLength(450);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.Message).HasMaxLength(2000);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.Type).HasDefaultValue((byte)1);

            entity.HasOne(d => d.AssignedTo).WithMany(p => p.ContactRequests)
                .HasForeignKey(d => d.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__CONTACT_R__Assig__46E78A0C");

            entity.HasOne(d => d.Product).WithMany(p => p.ContactRequests)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__CONTACT_R__Produ__45F365D3");
        });

        modelBuilder.Entity<ContentBlock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CONTENT___3214EC07D7D38033");

            entity.ToTable("CONTENT_BLOCK");

            entity.HasIndex(e => e.Key, "UQ__CONTENT___C41E0289CA4E811D").IsUnique();

            entity.Property(e => e.Group).HasDefaultValue((byte)1);
            entity.Property(e => e.Key).HasMaxLength(60);
            entity.Property(e => e.SortOrder).HasDefaultValue(0);
        });

        modelBuilder.Entity<EmailOutbox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMAIL_OU__3214EC07989DD526");

            entity.ToTable("EMAIL_OUTBOX");

            entity.Property(e => e.Attempts).HasDefaultValue(0);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.Subject).HasMaxLength(256);
            entity.Property(e => e.To).HasMaxLength(256);
        });

        modelBuilder.Entity<MediaFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MEDIA_FI__3214EC07C64AF674");

            entity.ToTable("MEDIA_FILE");

            entity.HasIndex(e => e.Path, "UQ__MEDIA_FI__A15FA6CBA0BCFA9D").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Path).HasMaxLength(260);
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PARTNER__3214EC071B620CB8");

            entity.ToTable("PARTNER");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsVisible).HasDefaultValue(true);
            entity.Property(e => e.LogoPath).HasMaxLength(260);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.ShowOnHome).HasDefaultValue(false);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT__3214EC0771068874");

            entity.ToTable("PRODUCT");

            entity.HasIndex(e => e.Slug, "UX_PRODUCT_Slug")
                .IsUnique()
                .HasFilter("([IsDeleted]=(0))");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsFeatured).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Rating).HasDefaultValue((byte)5);
            entity.Property(e => e.ShortDescription).HasMaxLength(500);
            entity.Property(e => e.ShortSpec).HasMaxLength(300);
            entity.Property(e => e.Slug).HasMaxLength(220);
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ViewCount).HasDefaultValue(0);
            entity.Property(e => e.WarrantyMonths).HasDefaultValue(0);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__PRODUCT__Categor__1BFD2C07");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___3214EC076B0C2B9A");

            entity.ToTable("PRODUCT_IMAGE");

            entity.Property(e => e.AltText).HasMaxLength(200);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsPrimary).HasDefaultValue(false);
            entity.Property(e => e.Path).HasMaxLength(260);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRODUCT_I__Produ__2B3F6F97");
        });

        modelBuilder.Entity<ProductVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PRODUCT___3214EC07D97EC9BC");

            entity.ToTable("PRODUCT_VARIANT");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDefault).HasDefaultValue(false);
            entity.Property(e => e.MaterialName).HasMaxLength(100);
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__PRODUCT_V__Produ__267ABA7A");
        });

        modelBuilder.Entity<SiteSetting>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK__SITE_SET__C41E02889F47A30F");

            entity.ToTable("SITE_SETTING");

            entity.Property(e => e.Key).HasMaxLength(100);
        });

        modelBuilder.Entity<SlugHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SLUG_HIS__3214EC07A7F6DD24");

            entity.ToTable("SLUG_HISTORY");

            entity.HasIndex(e => e.OldSlug, "UQ__SLUG_HIS__1FAE6ED7E8BA6AE8").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EntityType).HasMaxLength(50);
            entity.Property(e => e.OldSlug).HasMaxLength(220);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USER__3214EC07F280CC6F");

            entity.ToTable("USER");

            entity.HasIndex(e => e.Email, "UQ__USER__A9D10534742CA52F").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
