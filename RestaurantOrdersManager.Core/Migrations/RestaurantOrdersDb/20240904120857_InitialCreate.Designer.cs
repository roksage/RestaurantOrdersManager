﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOrdersManager.Infrastructure;

#nullable disable

namespace RestaurantOrdersManager.Core.Migrations.RestaurantOrdersDb
{
    [DbContext(typeof(RestaurantOrdersDbContext))]
    [Migration("20240904120857_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.ReservationSystem.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeopleCount")
                        .HasColumnType("int");

                    b.Property<string>("ReservationInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReservationId");

                    b.HasIndex("TableId");

                    b.HasIndex("VerificationCode")
                        .IsUnique();

                    b.ToTable("Reservations", (string)null);

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            Email = "test@email.com",
                            EndTime = new DateTime(2024, 9, 4, 17, 8, 56, 748, DateTimeKind.Local).AddTicks(9133),
                            PeopleCount = 0,
                            ReservationInfo = "Test Reservation",
                            ReservationStatus = 1,
                            StartTime = new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9132),
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 9, 4, 12, 8, 56, 748, DateTimeKind.Utc).AddTicks(9132),
                            VerificationCode = "ABCD"
                        },
                        new
                        {
                            ReservationId = 21,
                            Email = "test@email.com",
                            EndTime = new DateTime(2024, 9, 4, 18, 8, 56, 748, DateTimeKind.Local).AddTicks(9137),
                            PeopleCount = 0,
                            ReservationInfo = "Test Reservation2",
                            ReservationStatus = 1,
                            StartTime = new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9136),
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 9, 4, 12, 8, 56, 748, DateTimeKind.Utc).AddTicks(9135),
                            VerificationCode = "ABCDE"
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.CookingStation", b =>
                {
                    b.Property<int>("cookingStationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cookingStationId"));

                    b.Property<string>("cookingStationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cookingStationId");

                    b.ToTable("CookingStation", (string)null);

                    b.HasData(
                        new
                        {
                            cookingStationId = 1,
                            cookingStationName = "Friers"
                        },
                        new
                        {
                            cookingStationId = 2,
                            cookingStationName = "Garnishes"
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            LastName = "Doe",
                            Name = "John"
                        },
                        new
                        {
                            EmployeeId = 2,
                            LastName = "Smith",
                            Name = "Jane"
                        },
                        new
                        {
                            EmployeeId = 3,
                            LastName = "Johnson",
                            Name = "Alice"
                        },
                        new
                        {
                            EmployeeId = 4,
                            LastName = "Brown",
                            Name = "Bob"
                        },
                        new
                        {
                            EmployeeId = 5,
                            LastName = "Davis",
                            Name = "Charlie"
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<double>("IngredientAmount")
                        .HasColumnType("float");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IngredientUnit")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients", (string)null);

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            IngredientAmount = 500.0,
                            IngredientName = "Lettuce",
                            IngredientUnit = 1
                        },
                        new
                        {
                            IngredientId = 2,
                            IngredientAmount = 200.0,
                            IngredientName = "Tomato",
                            IngredientUnit = 1
                        },
                        new
                        {
                            IngredientId = 3,
                            IngredientAmount = 300.0,
                            IngredientName = "Cheese",
                            IngredientUnit = 1
                        },
                        new
                        {
                            IngredientId = 4,
                            IngredientAmount = 1000.0,
                            IngredientName = "Chicken",
                            IngredientUnit = 1
                        },
                        new
                        {
                            IngredientId = 5,
                            IngredientAmount = 700.0,
                            IngredientName = "Beef",
                            IngredientUnit = 1
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.IngredientInMenuItem", b =>
                {
                    b.Property<int>("IngredientInMenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientInMenuItemId"));

                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.HasKey("IngredientInMenuItemId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("IngredientsInMenuItem", (string)null);

                    b.HasData(
                        new
                        {
                            IngredientInMenuItemId = 1,
                            IngredientId = 1,
                            MenuItemId = 3
                        },
                        new
                        {
                            IngredientInMenuItemId = 2,
                            IngredientId = 2,
                            MenuItemId = 3
                        },
                        new
                        {
                            IngredientInMenuItemId = 3,
                            IngredientId = 3,
                            MenuItemId = 1
                        },
                        new
                        {
                            IngredientInMenuItemId = 4,
                            IngredientId = 4,
                            MenuItemId = 1
                        },
                        new
                        {
                            IngredientInMenuItemId = 5,
                            IngredientId = 5,
                            MenuItemId = 5
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<int>("CookingStationId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems", (string)null);

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            CookingStationId = 1,
                            ItemName = "Burger"
                        },
                        new
                        {
                            MenuItemId = 2,
                            CookingStationId = 1,
                            ItemName = "Pizza"
                        },
                        new
                        {
                            MenuItemId = 3,
                            CookingStationId = 2,
                            ItemName = "Salad"
                        },
                        new
                        {
                            MenuItemId = 4,
                            CookingStationId = 1,
                            ItemName = "Pasta"
                        },
                        new
                        {
                            MenuItemId = 5,
                            CookingStationId = 1,
                            ItemName = "Steak"
                        },
                        new
                        {
                            MenuItemId = 6,
                            CookingStationId = 2,
                            ItemName = "Sushi"
                        },
                        new
                        {
                            MenuItemId = 7,
                            CookingStationId = 1,
                            ItemName = "Tacos"
                        },
                        new
                        {
                            MenuItemId = 8,
                            CookingStationId = 2,
                            ItemName = "Sandwich"
                        },
                        new
                        {
                            MenuItemId = 9,
                            CookingStationId = 2,
                            ItemName = "Soup"
                        },
                        new
                        {
                            MenuItemId = 10,
                            CookingStationId = 2,
                            ItemName = "Ice Cream"
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.MenuItemToOrder", b =>
                {
                    b.Property<int>("OrderedMenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderedMenuItemId"));

                    b.Property<int>("CookingStationId")
                        .HasColumnType("int");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessCompleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProcessStarted")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderedMenuItemId");

                    b.HasIndex("CookingStationId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderMenuItems", (string)null);

                    b.HasData(
                        new
                        {
                            OrderedMenuItemId = 1,
                            CookingStationId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            ProcessStarted = new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9053)
                        },
                        new
                        {
                            OrderedMenuItemId = 2,
                            CookingStationId = 1,
                            MenuItemId = 2,
                            OrderId = 1,
                            ProcessStarted = new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9056)
                        },
                        new
                        {
                            OrderedMenuItemId = 3,
                            CookingStationId = 1,
                            MenuItemId = 3,
                            OrderId = 2,
                            ProcessStarted = new DateTime(2024, 9, 3, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9058)
                        },
                        new
                        {
                            OrderedMenuItemId = 4,
                            CookingStationId = 1,
                            MenuItemId = 4,
                            OrderId = 3,
                            ProcessStarted = new DateTime(2024, 9, 2, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9060)
                        },
                        new
                        {
                            OrderedMenuItemId = 5,
                            CookingStationId = 1,
                            MenuItemId = 5,
                            OrderId = 4,
                            ProcessStarted = new DateTime(2024, 9, 1, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9063)
                        },
                        new
                        {
                            OrderedMenuItemId = 6,
                            CookingStationId = 1,
                            MenuItemId = 6,
                            OrderId = 5,
                            ProcessStarted = new DateTime(2024, 8, 31, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9065)
                        },
                        new
                        {
                            OrderedMenuItemId = 7,
                            CookingStationId = 2,
                            MenuItemId = 7,
                            OrderId = 6,
                            ProcessStarted = new DateTime(2024, 8, 30, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9067)
                        },
                        new
                        {
                            OrderedMenuItemId = 8,
                            CookingStationId = 2,
                            MenuItemId = 8,
                            OrderId = 7,
                            ProcessStarted = new DateTime(2024, 8, 29, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9069)
                        },
                        new
                        {
                            OrderedMenuItemId = 9,
                            CookingStationId = 2,
                            MenuItemId = 9,
                            OrderId = 8,
                            ProcessStarted = new DateTime(2024, 8, 28, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9071)
                        },
                        new
                        {
                            OrderedMenuItemId = 10,
                            CookingStationId = 2,
                            MenuItemId = 10,
                            OrderId = 9,
                            ProcessStarted = new DateTime(2024, 8, 27, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9076)
                        },
                        new
                        {
                            OrderedMenuItemId = 11,
                            CookingStationId = 2,
                            MenuItemId = 1,
                            OrderId = 10,
                            ProcessStarted = new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9080)
                        },
                        new
                        {
                            OrderedMenuItemId = 12,
                            CookingStationId = 2,
                            MenuItemId = 2,
                            OrderId = 10,
                            ProcessStarted = new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9083)
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeFinished")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("TableId");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CreatedBy = 1,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9005)
                        },
                        new
                        {
                            OrderId = 2,
                            CreatedBy = 2,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 9, 3, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9009)
                        },
                        new
                        {
                            OrderId = 3,
                            CreatedBy = 3,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 9, 2, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9016)
                        },
                        new
                        {
                            OrderId = 4,
                            CreatedBy = 1,
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 9, 1, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9019)
                        },
                        new
                        {
                            OrderId = 5,
                            CreatedBy = 2,
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 8, 31, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9023)
                        },
                        new
                        {
                            OrderId = 6,
                            CreatedBy = 3,
                            TableId = 3,
                            TimeCreated = new DateTime(2024, 8, 30, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9026)
                        },
                        new
                        {
                            OrderId = 7,
                            CreatedBy = 1,
                            TableId = 3,
                            TimeCreated = new DateTime(2024, 8, 29, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9028)
                        },
                        new
                        {
                            OrderId = 8,
                            CreatedBy = 2,
                            TableId = 4,
                            TimeCreated = new DateTime(2024, 8, 28, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9030)
                        },
                        new
                        {
                            OrderId = 9,
                            CreatedBy = 3,
                            TableId = 4,
                            TimeCreated = new DateTime(2024, 8, 27, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9032)
                        },
                        new
                        {
                            OrderId = 10,
                            CreatedBy = 1,
                            TableId = 5,
                            TimeCreated = new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9034)
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TableId");

                    b.ToTable("Tables", (string)null);

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Seats = 0,
                            Status = 0,
                            TableName = "TakeAway"
                        },
                        new
                        {
                            TableId = 2,
                            Seats = 3,
                            Status = 0,
                            TableName = "Table 2"
                        },
                        new
                        {
                            TableId = 3,
                            Seats = 2,
                            Status = 0,
                            TableName = "Table 3"
                        },
                        new
                        {
                            TableId = 4,
                            Seats = 8,
                            Status = 0,
                            TableName = "Table 4"
                        },
                        new
                        {
                            TableId = 5,
                            Seats = 2,
                            Status = 0,
                            TableName = "Table 5"
                        },
                        new
                        {
                            TableId = 6,
                            Seats = 2,
                            Status = 0,
                            TableName = "Table 6"
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.ReservationSystem.Reservation", b =>
                {
                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.IngredientInMenuItem", b =>
                {
                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Ingredient", "Ingredient")
                        .WithMany("IngredientsInMenuItems")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.MenuItem", "MenuItem")
                        .WithMany("IngredientsInMenuItem")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.MenuItemToOrder", b =>
                {
                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.CookingStation", "CookingStation")
                        .WithMany("cookingStationOrders")
                        .HasForeignKey("CookingStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.MenuItem", "MenuItem")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CookingStation");

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Order", b =>
                {
                    b.HasOne("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.CookingStation", b =>
                {
                    b.Navigation("cookingStationOrders");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Ingredient", b =>
                {
                    b.Navigation("IngredientsInMenuItems");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.MenuItem", b =>
                {
                    b.Navigation("IngredientsInMenuItem");

                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Order", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.RestaurantOrders.Table", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
