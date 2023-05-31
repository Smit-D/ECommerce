using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.Entities;

namespace Data.Context
{
    public partial class ECommerceDBContext : DbContext
    {
        public ECommerceDBContext()
        {
        }

        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCart> TblCarts { get; set; } = null!;
        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblCity> TblCities { get; set; } = null!;
        public virtual DbSet<TblCompany> TblCompanies { get; set; } = null!;
        public virtual DbSet<TblCountry> TblCountries { get; set; } = null!;
        public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
        public virtual DbSet<TblPaymentMethod> TblPaymentMethods { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblProductMedium> TblProductMedia { get; set; } = null!;
        public virtual DbSet<TblProductRating> TblProductRatings { get; set; } = null!;
        public virtual DbSet<TblProductReview> TblProductReviews { get; set; } = null!;
        public virtual DbSet<TblProductReviewMedium> TblProductReviewMedia { get; set; } = null!;
        public virtual DbSet<TblProductSupplierMapping> TblProductSupplierMappings { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblSubCategory> TblSubCategories { get; set; } = null!;
        public virtual DbSet<TblSupplier> TblSuppliers { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;
        public virtual DbSet<TblUserAddress> TblUserAddresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__tblCarts__51BCD7B77F019CFE");

                entity.ToTable("tblCarts");

                entity.Property(e => e.IsRemoved).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCarts__Produc__1D4655FB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblCarts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tblCarts__UserId__1C5231C2");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__tblCateg__19093A0BBEFEA5DE");

                entity.ToTable("tblCategories");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__tblCitie__F2D21B76E217CC8F");

                entity.ToTable("tblCities");

                entity.Property(e => e.CityName)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblCities)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__tblCities__Count__2F10007B");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__tblCompa__2D971CACA29B8F2A");

                entity.ToTable("tblCompanies");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblCompanies)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__tblCompan__Count__4222D4EF");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__tblCount__10D1609F87BA0C74");

                entity.ToTable("tblCountries");

                entity.Property(e => e.CountryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CountryName)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__tblOrder__C3905BCFCFCF7F13");

                entity.ToTable("tblOrders");

                entity.Property(e => e.CanceledAt).HasColumnType("datetime");

                entity.Property(e => e.OrderedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.TotalAmountPaid).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrders__Payme__314D4EA8");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrders__Produ__30592A6F");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrders__Suppl__3335971A");

                entity.HasOne(d => d.UserAddress)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrders__UserA__324172E1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblOrders__UserI__2F650636");
            });

            modelBuilder.Entity<TblPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.PaymentMethodId)
                    .HasName("PK__tblPayme__DC31C1D3FEDB7247");

                entity.ToTable("tblPaymentMethods");

                entity.Property(e => e.PaymentMethodId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.PaymentMethodName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__tblProdu__B40CC6CDE036E7E9");

                entity.ToTable("tblProducts");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKU");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__tblProduc__Categ__1C873BEC");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__tblProduc__Compa__1B9317B3");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK__tblProduc__SubCa__1D7B6025");
            });

            modelBuilder.Entity<TblProductMedium>(entity =>
            {
                entity.HasKey(e => e.MediaId)
                    .HasName("PK__tblProdu__B2C2B5CF51FFD0D6");

                entity.ToTable("tblProductMedia");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsDefault).HasDefaultValueSql("((0))");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MediaUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MeidaName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductMedia)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__Produ__22401542");
            });

            modelBuilder.Entity<TblProductRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__tblProdu__FCCDF87CB4A96C2D");

                entity.ToTable("tblProductRatings");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductRatings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__Produ__0EF836A4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblProductRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__UserI__0E04126B");
            });

            modelBuilder.Entity<TblProductReview>(entity =>
            {
                entity.HasKey(e => e.ProductReviewId)
                    .HasName("PK__tblProdu__39631880FCA01CF4");

                entity.ToTable("tblProductReviews");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__Produ__13BCEBC1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblProductReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__UserI__12C8C788");
            });

            modelBuilder.Entity<TblProductReviewMedium>(entity =>
            {
                entity.HasKey(e => e.ReviewMediaId)
                    .HasName("PK__tblProdu__5C018B1C56ACF5AC");

                entity.ToTable("tblProductReviewMedia");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.MediaType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MediaUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MeidaName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.ProductReview)
                    .WithMany(p => p.TblProductReviewMedia)
                    .HasForeignKey(d => d.ProductReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblProduc__Produ__178D7CA5");
            });

            modelBuilder.Entity<TblProductSupplierMapping>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SupplierId })
                    .HasName("PK__tblProdu__E0B2A0A624B5802C");

                entity.ToTable("tblProductSupplierMapping");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__tblRoles__8AFACE1A25125F09");

                entity.ToTable("tblRoles");

                entity.Property(e => e.RoleId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Role)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId)
                    .HasName("PK__tblSubCa__26BE5B19D52687DC");

                entity.ToTable("tblSubCategories");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblSubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__tblSubCat__Categ__690797E6");
            });

            modelBuilder.Entity<TblSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK__tblSuppl__4BE666B4BEC85964");

                entity.ToTable("tblSuppliers");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUsers__1788CC4C95A21268");

                entity.ToTable("tblUsers");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImg)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUsers__CityId__093F5D4E");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUsers__Countr__084B3915");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__tblUsers__RoleId__0A338187");
            });

            modelBuilder.Entity<TblUserAddress>(entity =>
            {
                entity.HasKey(e => e.UserAddressId)
                    .HasName("PK__tblUserA__5961BBB7BD06D404");

                entity.ToTable("tblUserAddresses");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblUserAddresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserAd__CityI__2AA05119");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblUserAddresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserAd__Count__29AC2CE0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblUserAd__UserI__28B808A7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
