using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities;

namespace RestaurantOrdersManager.Infrastructure
{
    public class ManagerDbContext : DbContext
    {
        public ManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedMenuItem> OrderMenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItems");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderedMenuItem>().ToTable("OrderMenuItems");

            modelBuilder.Entity<Employee>()
                .Property(f => f.EmployeeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MenuItem>()
                .Property(f => f.MenuItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(f => f.OrderId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderedMenuItem>()
                .Property(f => f.OrderedMenuItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderedMenuItem>()
                .HasOne(om => om.Order)
                .WithMany(o => o.OrderMenuItems)
                .HasForeignKey(om => om.OrderId);

            modelBuilder.Entity<OrderedMenuItem>()
                .HasOne(om => om.MenuItem)
                .WithMany(m => m.OrderMenuItems)
                .HasForeignKey(om => om.MenuItemId);
        }
    }
}
