﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOrdersManager.Infrastructure;

#nullable disable

namespace RestaurantOrdersManager.Core.Migrations
{
    [DbContext(typeof(ManagerDbContext))]
    partial class ManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.Employee", b =>
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

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems", (string)null);

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            ItemName = "Burger"
                        },
                        new
                        {
                            MenuItemId = 2,
                            ItemName = "Pizza"
                        },
                        new
                        {
                            MenuItemId = 3,
                            ItemName = "Salad"
                        },
                        new
                        {
                            MenuItemId = 4,
                            ItemName = "Pasta"
                        },
                        new
                        {
                            MenuItemId = 5,
                            ItemName = "Steak"
                        },
                        new
                        {
                            MenuItemId = 6,
                            ItemName = "Sushi"
                        },
                        new
                        {
                            MenuItemId = 7,
                            ItemName = "Tacos"
                        },
                        new
                        {
                            MenuItemId = 8,
                            ItemName = "Sandwich"
                        },
                        new
                        {
                            MenuItemId = 9,
                            ItemName = "Soup"
                        },
                        new
                        {
                            MenuItemId = 10,
                            ItemName = "Ice Cream"
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.MenuItemToOrder", b =>
                {
                    b.Property<int>("OrderedMenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderedMenuItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ProcessCompleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProcessStarted")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderedMenuItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderMenuItems", (string)null);

                    b.HasData(
                        new
                        {
                            OrderedMenuItemId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            ProcessStarted = new DateTime(2024, 7, 18, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5408)
                        },
                        new
                        {
                            OrderedMenuItemId = 2,
                            MenuItemId = 2,
                            OrderId = 1,
                            ProcessStarted = new DateTime(2024, 7, 18, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5410)
                        },
                        new
                        {
                            OrderedMenuItemId = 3,
                            MenuItemId = 3,
                            OrderId = 2,
                            ProcessStarted = new DateTime(2024, 7, 17, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5412)
                        },
                        new
                        {
                            OrderedMenuItemId = 4,
                            MenuItemId = 4,
                            OrderId = 3,
                            ProcessStarted = new DateTime(2024, 7, 16, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5414)
                        },
                        new
                        {
                            OrderedMenuItemId = 5,
                            MenuItemId = 5,
                            OrderId = 4,
                            ProcessStarted = new DateTime(2024, 7, 15, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5416)
                        },
                        new
                        {
                            OrderedMenuItemId = 6,
                            MenuItemId = 6,
                            OrderId = 5,
                            ProcessStarted = new DateTime(2024, 7, 14, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5418)
                        },
                        new
                        {
                            OrderedMenuItemId = 7,
                            MenuItemId = 7,
                            OrderId = 6,
                            ProcessStarted = new DateTime(2024, 7, 13, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5420)
                        },
                        new
                        {
                            OrderedMenuItemId = 8,
                            MenuItemId = 8,
                            OrderId = 7,
                            ProcessStarted = new DateTime(2024, 7, 12, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5422)
                        },
                        new
                        {
                            OrderedMenuItemId = 9,
                            MenuItemId = 9,
                            OrderId = 8,
                            ProcessStarted = new DateTime(2024, 7, 11, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5424)
                        },
                        new
                        {
                            OrderedMenuItemId = 10,
                            MenuItemId = 10,
                            OrderId = 9,
                            ProcessStarted = new DateTime(2024, 7, 10, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5426)
                        },
                        new
                        {
                            OrderedMenuItemId = 11,
                            MenuItemId = 1,
                            OrderId = 10,
                            ProcessStarted = new DateTime(2024, 7, 9, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5428)
                        },
                        new
                        {
                            OrderedMenuItemId = 12,
                            MenuItemId = 2,
                            OrderId = 10,
                            ProcessStarted = new DateTime(2024, 7, 9, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5430)
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.Order", b =>
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
                            TimeCreated = new DateTime(2024, 7, 18, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5338)
                        },
                        new
                        {
                            OrderId = 2,
                            CreatedBy = 2,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 7, 17, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5341)
                        },
                        new
                        {
                            OrderId = 3,
                            CreatedBy = 3,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 7, 16, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5345)
                        },
                        new
                        {
                            OrderId = 4,
                            CreatedBy = 1,
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 7, 15, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5347)
                        },
                        new
                        {
                            OrderId = 5,
                            CreatedBy = 2,
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 7, 14, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5349)
                        },
                        new
                        {
                            OrderId = 6,
                            CreatedBy = 3,
                            TableId = 3,
                            TimeCreated = new DateTime(2024, 7, 13, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5352)
                        },
                        new
                        {
                            OrderId = 7,
                            CreatedBy = 1,
                            TableId = 3,
                            TimeCreated = new DateTime(2024, 7, 12, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5354)
                        },
                        new
                        {
                            OrderId = 8,
                            CreatedBy = 2,
                            TableId = 4,
                            TimeCreated = new DateTime(2024, 7, 11, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5356)
                        },
                        new
                        {
                            OrderId = 9,
                            CreatedBy = 3,
                            TableId = 4,
                            TimeCreated = new DateTime(2024, 7, 10, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5358)
                        },
                        new
                        {
                            OrderId = 10,
                            CreatedBy = 1,
                            TableId = 5,
                            TimeCreated = new DateTime(2024, 7, 9, 9, 22, 8, 917, DateTimeKind.Local).AddTicks(5360)
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.Table", b =>
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
                        });
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.MenuItemToOrder", b =>
                {
                    b.HasOne("RestaurantOrdersManager.Core.Entities.MenuItem", "MenuItem")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RestaurantOrdersManager.Core.Entities.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.Order", b =>
                {
                    b.HasOne("RestaurantOrdersManager.Core.Entities.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.MenuItem", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.Order", b =>
                {
                    b.Navigation("OrderMenuItems");
                });

            modelBuilder.Entity("RestaurantOrdersManager.Core.Entities.Table", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
