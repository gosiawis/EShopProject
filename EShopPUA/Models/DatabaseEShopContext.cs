using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EShopPUA.Models
{
    public partial class DatabaseEShopContext : DbContext
    {
        public DatabaseEShopContext()
        {
        }

        public DatabaseEShopContext(DbContextOptions<DatabaseEShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Voivodeship> Voivodeships { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=WIN-AKLSU3I1TSV\\SQLEXPRESS;Database=DatabaseEShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatetdBy)
                    .HasColumnName("createtd_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("carts");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cart_items_product_id_fk");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatetdBy)
                    .HasColumnName("createtd_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentNumber).HasColumnName("apartment_number");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatetdBy)
                    .HasColumnName("createtd_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.HouseNumber).HasColumnName("house_number");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.VoivodeshipId).HasColumnName("voivodeship_id");

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");

                entity.HasOne(d => d.Voivodeship)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.VoivodeshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clients_voivodeship_id_fk");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("start_date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_client_id_fk");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_status_id_fk");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_payment_method_id_fk");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_payment_status_id_fk");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_items");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_itmes_order_id_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_items_product_id_fk");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("order_statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("payment_methods");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.ToTable("payment_statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatetdBy)
                    .HasColumnName("createtd_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Picture).HasColumnName("picture");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_brand_id_fk");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("products_category_id_fk");
            });

            modelBuilder.Entity<Voivodeship>(entity =>
            {
                entity.ToTable("voivodeships");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
