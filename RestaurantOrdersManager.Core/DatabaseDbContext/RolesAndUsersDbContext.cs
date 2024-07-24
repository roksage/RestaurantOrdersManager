using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Entities.RolesAndUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.DatabaseDbContext
{
    public class RolesAndUsersDbContext : DbContext
    {
        public RolesAndUsersDbContext(DbContextOptions<RolesAndUsersDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

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



            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin",
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                Username = "user",
                Password = "user",
                Role = "User"
            });





            modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
