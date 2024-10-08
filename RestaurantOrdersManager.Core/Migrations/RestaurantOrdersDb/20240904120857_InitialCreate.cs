﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrdersManager.Core.Migrations.RestaurantOrdersDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookingStation",
                columns: table => new
                {
                    cookingStationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cookingStationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingStation", x => x.cookingStationId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientUnit = table.Column<int>(type: "int", nullable: false),
                    IngredientAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CookingStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsInMenuItem",
                columns: table => new
                {
                    IngredientInMenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsInMenuItem", x => x.IngredientInMenuItemId);
                    table.ForeignKey(
                        name: "FK_IngredientsInMenuItem_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientsInMenuItem_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeFinished = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationStatus = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    PeopleCount = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenuItems",
                columns: table => new
                {
                    OrderedMenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    ProcessStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CookingStationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItems", x => x.OrderedMenuItemId);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_CookingStation_CookingStationId",
                        column: x => x.CookingStationId,
                        principalTable: "CookingStation",
                        principalColumn: "cookingStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "MenuItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CookingStation",
                columns: new[] { "cookingStationId", "cookingStationName" },
                values: new object[,]
                {
                    { 1, "Friers" },
                    { 2, "Garnishes" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "Doe", "John" },
                    { 2, "Smith", "Jane" },
                    { 3, "Johnson", "Alice" },
                    { 4, "Brown", "Bob" },
                    { 5, "Davis", "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "IngredientAmount", "IngredientName", "IngredientUnit" },
                values: new object[,]
                {
                    { 1, 500.0, "Lettuce", 1 },
                    { 2, 200.0, "Tomato", 1 },
                    { 3, 300.0, "Cheese", 1 },
                    { 4, 1000.0, "Chicken", 1 },
                    { 5, 700.0, "Beef", 1 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "CookingStationId", "ItemName" },
                values: new object[,]
                {
                    { 1, 1, "Burger" },
                    { 2, 1, "Pizza" },
                    { 3, 2, "Salad" },
                    { 4, 1, "Pasta" },
                    { 5, 1, "Steak" },
                    { 6, 2, "Sushi" },
                    { 7, 1, "Tacos" },
                    { 8, 2, "Sandwich" },
                    { 9, 2, "Soup" },
                    { 10, 2, "Ice Cream" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Seats", "Status", "TableName" },
                values: new object[,]
                {
                    { 1, 0, 0, "TakeAway" },
                    { 2, 3, 0, "Table 2" },
                    { 3, 2, 0, "Table 3" },
                    { 4, 8, 0, "Table 4" },
                    { 5, 2, 0, "Table 5" },
                    { 6, 2, 0, "Table 6" }
                });

            migrationBuilder.InsertData(
                table: "IngredientsInMenuItem",
                columns: new[] { "IngredientInMenuItemId", "IngredientId", "MenuItemId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 3 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "TableId", "TimeCreated", "TimeFinished" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9005), null },
                    { 2, 2, 1, new DateTime(2024, 9, 3, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9009), null },
                    { 3, 3, 1, new DateTime(2024, 9, 2, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9016), null },
                    { 4, 1, 2, new DateTime(2024, 9, 1, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9019), null },
                    { 5, 2, 2, new DateTime(2024, 8, 31, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9023), null },
                    { 6, 3, 3, new DateTime(2024, 8, 30, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9026), null },
                    { 7, 1, 3, new DateTime(2024, 8, 29, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9028), null },
                    { 8, 2, 4, new DateTime(2024, 8, 28, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9030), null },
                    { 9, 3, 4, new DateTime(2024, 8, 27, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9032), null },
                    { 10, 1, 5, new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9034), null }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Email", "EndTime", "PeopleCount", "ReservationInfo", "ReservationStatus", "StartTime", "TableId", "TimeCreated", "VerificationCode" },
                values: new object[,]
                {
                    { 1, "test@email.com", new DateTime(2024, 9, 4, 17, 8, 56, 748, DateTimeKind.Local).AddTicks(9133), 0, "Test Reservation", 1, new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9132), 2, new DateTime(2024, 9, 4, 12, 8, 56, 748, DateTimeKind.Utc).AddTicks(9132), "ABCD" },
                    { 21, "test@email.com", new DateTime(2024, 9, 4, 18, 8, 56, 748, DateTimeKind.Local).AddTicks(9137), 0, "Test Reservation2", 1, new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9136), 2, new DateTime(2024, 9, 4, 12, 8, 56, 748, DateTimeKind.Utc).AddTicks(9135), "ABCDE" }
                });

            migrationBuilder.InsertData(
                table: "OrderMenuItems",
                columns: new[] { "OrderedMenuItemId", "CookingStationId", "MenuItemId", "OrderId", "ProcessCompleted", "ProcessStarted" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9053) },
                    { 2, 1, 2, 1, null, new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9056) },
                    { 3, 1, 3, 2, null, new DateTime(2024, 9, 3, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9058) },
                    { 4, 1, 4, 3, null, new DateTime(2024, 9, 2, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9060) },
                    { 5, 1, 5, 4, null, new DateTime(2024, 9, 1, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9063) },
                    { 6, 1, 6, 5, null, new DateTime(2024, 8, 31, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9065) },
                    { 7, 2, 7, 6, null, new DateTime(2024, 8, 30, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9067) },
                    { 8, 2, 8, 7, null, new DateTime(2024, 8, 29, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9069) },
                    { 9, 2, 9, 8, null, new DateTime(2024, 8, 28, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9071) },
                    { 10, 2, 10, 9, null, new DateTime(2024, 8, 27, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9076) },
                    { 11, 2, 1, 10, null, new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9080) },
                    { 12, 2, 2, 10, null, new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9083) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInMenuItem_IngredientId",
                table: "IngredientsInMenuItem",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsInMenuItem_MenuItemId",
                table: "IngredientsInMenuItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_CookingStationId",
                table: "OrderMenuItems",
                column: "CookingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_MenuItemId",
                table: "OrderMenuItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_OrderId",
                table: "OrderMenuItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VerificationCode",
                table: "Reservations",
                column: "VerificationCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "IngredientsInMenuItem");

            migrationBuilder.DropTable(
                name: "OrderMenuItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "CookingStation");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
