using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;

namespace RestaurantOrdersManager.Infrastructure
{
    public class RestaurantOrdersDbContext : DbContext
    {
        public RestaurantOrdersDbContext(DbContextOptions<RestaurantOrdersDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<MenuItemToOrder> OrderMenuItems { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientInMenuItem> IngredientsInMenuItem { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

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
            modelBuilder.Entity<Table>().ToTable("Tables");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<IngredientInMenuItem>().ToTable("IngredientsInMenuItem");
            modelBuilder.Entity<Reservation>().ToFunction("Reservations");


            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, TableName = "TakeAway", Seats = 0, Status = Core.Enums.TableStatusEnums.Free },
                new Table { TableId = 2, TableName = "Table 2", Seats = 3, Status = Core.Enums.TableStatusEnums.Free },
                new Table { TableId = 3, TableName = "Table 3", Seats = 2, Status = Core.Enums.TableStatusEnums.Free },
                new Table { TableId = 4, TableName = "Table 4", Seats = 8, Status = Core.Enums.TableStatusEnums.Free },
                new Table { TableId = 5, TableName = "Table 5", Seats = 2, Status = Core.Enums.TableStatusEnums.Free },
                new Table { TableId = 6, TableName = "Table 6", Seats = 2, Status = Core.Enums.TableStatusEnums.Free }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, Name = "John", LastName = "Doe" },
                new Employee { EmployeeId = 2, Name = "Jane", LastName = "Smith" },
                new Employee { EmployeeId = 3, Name = "Alice", LastName = "Johnson" },
                new Employee { EmployeeId = 4, Name = "Bob", LastName = "Brown" },
                new Employee { EmployeeId = 5, Name = "Charlie", LastName = "Davis" }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { MenuItemId = 1, ItemName = "Burger" },
                new MenuItem { MenuItemId = 2, ItemName = "Pizza" },
                new MenuItem { MenuItemId = 3, ItemName = "Salad" },
                new MenuItem { MenuItemId = 4, ItemName = "Pasta" },
                new MenuItem { MenuItemId = 5, ItemName = "Steak" },
                new MenuItem { MenuItemId = 6, ItemName = "Sushi" },
                new MenuItem { MenuItemId = 7, ItemName = "Tacos" },
                new MenuItem { MenuItemId = 8, ItemName = "Sandwich" },
                new MenuItem { MenuItemId = 9, ItemName = "Soup" },
                new MenuItem { MenuItemId = 10, ItemName = "Ice Cream" }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CreatedBy = 1, TableId = 1, TimeCreated = DateTime.Now },
                new Order { OrderId = 2, CreatedBy = 2, TableId = 1, TimeCreated = DateTime.Now.AddDays(-1) },
                new Order { OrderId = 3, CreatedBy = 3, TableId = 1, TimeCreated = DateTime.Now.AddDays(-2) },
                new Order { OrderId = 4, CreatedBy = 1, TableId = 2, TimeCreated = DateTime.Now.AddDays(-3) },
                new Order { OrderId = 5, CreatedBy = 2, TableId = 2, TimeCreated = DateTime.Now.AddDays(-4) },
                new Order { OrderId = 6, CreatedBy = 3, TableId = 3, TimeCreated = DateTime.Now.AddDays(-5) },
                new Order { OrderId = 7, CreatedBy = 1, TableId = 3, TimeCreated = DateTime.Now.AddDays(-6) },
                new Order { OrderId = 8, CreatedBy = 2, TableId = 4, TimeCreated = DateTime.Now.AddDays(-7) },
                new Order { OrderId = 9, CreatedBy = 3, TableId = 4, TimeCreated = DateTime.Now.AddDays(-8) },
                new Order { OrderId = 10, CreatedBy = 1, TableId = 5, TimeCreated = DateTime.Now.AddDays(-9) }
            );

            modelBuilder.Entity<MenuItemToOrder>().HasData(
                new MenuItemToOrder { OrderedMenuItemId = 1, OrderId = 1, MenuItemId = 1, ProcessStarted = DateTime.Now },
                new MenuItemToOrder { OrderedMenuItemId = 2, OrderId = 1, MenuItemId = 2, ProcessStarted = DateTime.Now },
                new MenuItemToOrder { OrderedMenuItemId = 3, OrderId = 2, MenuItemId = 3, ProcessStarted = DateTime.Now.AddDays(-1) },
                new MenuItemToOrder { OrderedMenuItemId = 4, OrderId = 3, MenuItemId = 4, ProcessStarted = DateTime.Now.AddDays(-2) },
                new MenuItemToOrder { OrderedMenuItemId = 5, OrderId = 4, MenuItemId = 5, ProcessStarted = DateTime.Now.AddDays(-3) },
                new MenuItemToOrder { OrderedMenuItemId = 6, OrderId = 5, MenuItemId = 6, ProcessStarted = DateTime.Now.AddDays(-4) },
                new MenuItemToOrder { OrderedMenuItemId = 7, OrderId = 6, MenuItemId = 7, ProcessStarted = DateTime.Now.AddDays(-5) },
                new MenuItemToOrder { OrderedMenuItemId = 8, OrderId = 7, MenuItemId = 8, ProcessStarted = DateTime.Now.AddDays(-6) },
                new MenuItemToOrder { OrderedMenuItemId = 9, OrderId = 8, MenuItemId = 9, ProcessStarted = DateTime.Now.AddDays(-7) },
                new MenuItemToOrder { OrderedMenuItemId = 10, OrderId = 9, MenuItemId = 10, ProcessStarted = DateTime.Now.AddDays(-8) },
                new MenuItemToOrder { OrderedMenuItemId = 11, OrderId = 10, MenuItemId = 1, ProcessStarted = DateTime.Now.AddDays(-9) },
                new MenuItemToOrder { OrderedMenuItemId = 12, OrderId = 10, MenuItemId = 2, ProcessStarted = DateTime.Now.AddDays(-9) }
            );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, IngredientName = "Lettuce", IngredientUnit = IngredientEnums.Gram, IngredientAmount = 500 },
                new Ingredient { IngredientId = 2, IngredientName = "Tomato", IngredientUnit = IngredientEnums.Gram, IngredientAmount = 200 },
                new Ingredient { IngredientId = 3, IngredientName = "Cheese", IngredientUnit = IngredientEnums.Gram, IngredientAmount = 300 },
                new Ingredient { IngredientId = 4, IngredientName = "Chicken", IngredientUnit = IngredientEnums.Gram, IngredientAmount = 1000 },
                new Ingredient { IngredientId = 5, IngredientName = "Beef", IngredientUnit = IngredientEnums.Gram, IngredientAmount = 700 }
            );


            modelBuilder.Entity<IngredientInMenuItem>().HasData(
                new IngredientInMenuItem { IngredientInMenuItemId = 1, IngredientId = 1, MenuItemId = 3 },
                new IngredientInMenuItem { IngredientInMenuItemId = 2, IngredientId = 2, MenuItemId = 3 },
                new IngredientInMenuItem { IngredientInMenuItemId = 3, IngredientId = 3, MenuItemId = 1 },
                new IngredientInMenuItem { IngredientInMenuItemId = 4, IngredientId = 4, MenuItemId = 1 },
                new IngredientInMenuItem { IngredientInMenuItemId = 5, IngredientId = 5, MenuItemId = 5 }
            );

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, ReservationInfo = "Test Reservation", StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), TableId = 2 }
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

            modelBuilder.Entity<Table>()
                .Property(f => f.TableId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ingredient>()
                .Property(f => f.IngredientId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<IngredientInMenuItem>()
                .Property(f => f.IngredientId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Reservation>()
                .Property (f => f.ReservationId)
                .ValueGeneratedOnAdd();




            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MenuItemToOrder>()
                .HasOne(om => om.Order)
                .WithMany(o => o.OrderMenuItems)
                .HasForeignKey(om => om.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MenuItemToOrder>()
                .HasOne(om => om.MenuItem)
                .WithMany(m => m.OrderMenuItems)
                .HasForeignKey(om => om.MenuItemId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<IngredientInMenuItem>()
                .HasOne(im => im.Ingredient)
                .WithMany(m => m.IngredientsInMenuItems)
                .HasForeignKey(im => im.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(o => o.Table)
                .WithMany(o => o.Reservations)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
