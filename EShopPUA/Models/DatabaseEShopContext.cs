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

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientsAddress> ClientsAddresses { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=WIN-AKLSU3I1TSV\\SQLEXPRESS;Database=DatabaseEShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentNumber).HasColumnName("apartment_number");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.HouseNumber).HasColumnName("house_number");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("addresses_district_id_fk");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataAdded)
                    .HasColumnType("datetime")
                    .HasColumnName("data_added");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataAdded)
                    .HasColumnType("datetime")
                    .HasColumnName("data_added");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<ClientsAddress>(entity =>
            {
                entity.ToTable("clients_addresses");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ClientsAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clients_addresses_address_id_fk");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientsAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clients_addresses_client_id_fk");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("districts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
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
                    .HasColumnName("start_date");

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

                entity.Property(e => e.DataAdded)
                    .HasColumnType("datetime")
                    .HasColumnName("data_added");

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

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stocks");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stocks_product_id_fk");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stocks_warehouse_id_fk");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApartmentNumber).HasColumnName("apartment_number");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.DistrictId).HasColumnName("district_id");

                entity.Property(e => e.HouseNumber).HasColumnName("house_number");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("warehouses_district_id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
