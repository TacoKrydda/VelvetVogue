using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Models.Sales;

namespace WebbShopClassLibrary.Context
{
    public class WebbShopContext : DbContext
    {
        public WebbShopContext(DbContextOptions<WebbShopContext> options) : base(options)
        {
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStaffAssignment> OrderStaffAssignments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .HasOne(p=>p.Stock)
            //    .WithOne(s=>s.Product)
            //    .HasForeignKey<Stock>(s=>s.ProductId);

            //modelBuilder.Entity<OrderStaffAssignment>()
            //    .HasOne(osa => osa.Order)
            //    .WithMany(o => o.OrderStaffAssignments)
            //    .HasForeignKey(osa => osa.OrderId);

            //modelBuilder.Entity<OrderStaffAssignment>()
            //    .HasOne(osa => osa.Staff)
            //    .WithMany(s => s.OrderStaffAssignments)
            //    .HasForeignKey(osa => osa.StaffId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
