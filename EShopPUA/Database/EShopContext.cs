using EShopPUA.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopPUA.Database
{
    public class EShopContext : DbContext
    {
        public EShopContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //entities
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderStatuses> OrderStatuses { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        public DbSet<PaymentStatuses> PaymentStatuses { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }


    }
}
