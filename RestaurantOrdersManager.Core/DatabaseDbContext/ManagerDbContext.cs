using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public virtual DbSet<MenuItemToOrder> OrderMenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure DbContext options, including logging
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

                // Enable sensitive data logging (if needed)
                optionsBuilder.EnableSensitiveDataLogging();

                // Set up logging to log SQL commands
                optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItems");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<MenuItemToOrder>().ToTable("OrderMenuItems");


            modelBuilder.Entity<MenuItem>().HasData(
     new MenuItem { MenuItemId = 1, ItemName = "Burger" },
     new MenuItem { MenuItemId = 2, ItemName = "Pizza" },
     new MenuItem { MenuItemId = 3, ItemName = "Salad" },
     new MenuItem { MenuItemId = 4, ItemName = "Pasta" }
 // Add more items as needed
 );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CreatedBy = 1, TimeCreated = DateTime.Now },
                new Order { OrderId = 2, CreatedBy = 2, TimeCreated = DateTime.Now.AddDays(-1) },
                new Order { OrderId = 3, CreatedBy = 3, TimeCreated = DateTime.Now.AddDays(-2) }
            // Add more orders as needed
            );

            // Seed data for MenuItemToOrder (linking MenuItems to Orders)
            modelBuilder.Entity<MenuItemToOrder>().HasData(
                new MenuItemToOrder { OrderedMenuItemId = 1, OrderId = 1, MenuItemId = 1, ProcessStarted = DateTime.Now },
                new MenuItemToOrder { OrderedMenuItemId = 2, OrderId = 1, MenuItemId = 2, ProcessStarted = DateTime.Now },
                new MenuItemToOrder { OrderedMenuItemId = 3, OrderId = 2, MenuItemId = 3, ProcessStarted = DateTime.Now.AddDays(-1) },
                new MenuItemToOrder { OrderedMenuItemId = 4, OrderId = 3, MenuItemId = 4, ProcessStarted = DateTime.Now.AddDays(-2) }
            // Add more MenuItemToOrder entries as needed
            );


            modelBuilder.Entity<Employee>()
                .Property(f => f.EmployeeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MenuItem>()
                .Property(f => f.MenuItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .Property(f => f.OrderId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MenuItemToOrder>()
                .Property(f => f.OrderedMenuItemId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MenuItemToOrder>()
                .HasOne(om => om.Order)
                .WithMany(o => o.OrderMenuItems)
                .HasForeignKey(om => om.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Configure delete behavior

            modelBuilder.Entity<MenuItemToOrder>()
                .HasOne(om => om.MenuItem)
                .WithMany(m => m.OrderMenuItems)
                .HasForeignKey(om => om.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict); // Ensure MenuItem is not deleted if MenuItemToOrder exists
        }
    }
}
