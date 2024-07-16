﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantOrdersManager.Infrastructure;

#nullable disable

namespace RestaurantOrdersManager.Core.Migrations
{
    [DbContext(typeof(ManagerDbContext))]
    [Migration("20240716120747_Inititial")]
    partial class Inititial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
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
                            ProcessStarted = new DateTime(2024, 7, 16, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8165)
                        },
                        new
                        {
                            OrderedMenuItemId = 2,
                            MenuItemId = 2,
                            OrderId = 1,
                            ProcessStarted = new DateTime(2024, 7, 16, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8168)
                        },
                        new
                        {
                            OrderedMenuItemId = 3,
                            MenuItemId = 3,
                            OrderId = 2,
                            ProcessStarted = new DateTime(2024, 7, 15, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8170)
                        },
                        new
                        {
                            OrderedMenuItemId = 4,
                            MenuItemId = 4,
                            OrderId = 3,
                            ProcessStarted = new DateTime(2024, 7, 14, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8172)
                        },
                        new
                        {
                            OrderedMenuItemId = 5,
                            MenuItemId = 5,
                            OrderId = 4,
                            ProcessStarted = new DateTime(2024, 7, 13, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8174)
                        },
                        new
                        {
                            OrderedMenuItemId = 6,
                            MenuItemId = 6,
                            OrderId = 5,
                            ProcessStarted = new DateTime(2024, 7, 12, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8176)
                        },
                        new
                        {
                            OrderedMenuItemId = 7,
                            MenuItemId = 7,
                            OrderId = 6,
                            ProcessStarted = new DateTime(2024, 7, 11, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8178)
                        },
                        new
                        {
                            OrderedMenuItemId = 8,
                            MenuItemId = 8,
                            OrderId = 7,
                            ProcessStarted = new DateTime(2024, 7, 10, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8180)
                        },
                        new
                        {
                            OrderedMenuItemId = 9,
                            MenuItemId = 9,
                            OrderId = 8,
                            ProcessStarted = new DateTime(2024, 7, 9, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8183)
                        },
                        new
                        {
                            OrderedMenuItemId = 10,
                            MenuItemId = 10,
                            OrderId = 9,
                            ProcessStarted = new DateTime(2024, 7, 8, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8186)
                        },
                        new
                        {
                            OrderedMenuItemId = 11,
                            MenuItemId = 1,
                            OrderId = 10,
                            ProcessStarted = new DateTime(2024, 7, 7, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8194)
                        },
                        new
                        {
                            OrderedMenuItemId = 12,
                            MenuItemId = 2,
                            OrderId = 10,
                            ProcessStarted = new DateTime(2024, 7, 7, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8197)
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
                            TimeCreated = new DateTime(2024, 7, 16, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8122)
                        },
                        new
                        {
                            OrderId = 2,
                            CreatedBy = 2,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 7, 15, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8125)
                        },
                        new
                        {
                            OrderId = 3,
                            CreatedBy = 3,
                            TableId = 1,
                            TimeCreated = new DateTime(2024, 7, 14, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8131)
                        },
                        new
                        {
                            OrderId = 4,
                            CreatedBy = 1,
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 7, 13, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8134)
                        },
                        new
                        {
                            OrderId = 5,
                            CreatedBy = 2,
                            TableId = 2,
                            TimeCreated = new DateTime(2024, 7, 12, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8138)
                        },
                        new
                        {
                            OrderId = 6,
                            CreatedBy = 3,
                            TableId = 3,
                            TimeCreated = new DateTime(2024, 7, 11, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8140)
                        },
                        new
                        {
                            OrderId = 7,
                            CreatedBy = 1,
                            TableId = 3,
                            TimeCreated = new DateTime(2024, 7, 10, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8142)
                        },
                        new
                        {
                            OrderId = 8,
                            CreatedBy = 2,
                            TableId = 4,
                            TimeCreated = new DateTime(2024, 7, 9, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8145)
                        },
                        new
                        {
                            OrderId = 9,
                            CreatedBy = 3,
                            TableId = 4,
                            TimeCreated = new DateTime(2024, 7, 8, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8147)
                        },
                        new
                        {
                            OrderId = 10,
                            CreatedBy = 1,
                            TableId = 5,
                            TimeCreated = new DateTime(2024, 7, 7, 15, 7, 47, 621, DateTimeKind.Local).AddTicks(8149)
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

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TableId");

                    b.ToTable("Tables", (string)null);

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Seats = 0,
                            TableName = "TakeAway"
                        },
                        new
                        {
                            TableId = 2,
                            Seats = 3,
                            TableName = "Table 2"
                        },
                        new
                        {
                            TableId = 3,
                            Seats = 2,
                            TableName = "Table 3"
                        },
                        new
                        {
                            TableId = 4,
                            Seats = 8,
                            TableName = "Table 4"
                        },
                        new
                        {
                            TableId = 5,
                            Seats = 2,
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