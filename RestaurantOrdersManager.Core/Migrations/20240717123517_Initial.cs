using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrdersManager.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "OrderMenuItems",
                columns: table => new
                {
                    OrderedMenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    ProcessStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcessCompleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItems", x => x.OrderedMenuItemId);
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
                table: "MenuItems",
                columns: new[] { "MenuItemId", "ItemName" },
                values: new object[,]
                {
                    { 1, "Burger" },
                    { 2, "Pizza" },
                    { 3, "Salad" },
                    { 4, "Pasta" },
                    { 5, "Steak" },
                    { 6, "Sushi" },
                    { 7, "Tacos" },
                    { 8, "Sandwich" },
                    { 9, "Soup" },
                    { 10, "Ice Cream" }
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
                    { 5, 2, 0, "Table 5" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CreatedBy", "TableId", "TimeCreated", "TimeFinished" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 7, 17, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3102), null },
                    { 2, 2, 1, new DateTime(2024, 7, 16, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3106), null },
                    { 3, 3, 1, new DateTime(2024, 7, 15, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3111), null },
                    { 4, 1, 2, new DateTime(2024, 7, 14, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3114), null },
                    { 5, 2, 2, new DateTime(2024, 7, 13, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3116), null },
                    { 6, 3, 3, new DateTime(2024, 7, 12, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3118), null },
                    { 7, 1, 3, new DateTime(2024, 7, 11, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3120), null },
                    { 8, 2, 4, new DateTime(2024, 7, 10, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3123), null },
                    { 9, 3, 4, new DateTime(2024, 7, 9, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3125), null },
                    { 10, 1, 5, new DateTime(2024, 7, 8, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3157), null }
                });

            migrationBuilder.InsertData(
                table: "OrderMenuItems",
                columns: new[] { "OrderedMenuItemId", "MenuItemId", "OrderId", "ProcessCompleted", "ProcessStarted" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2024, 7, 17, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3175) },
                    { 2, 2, 1, null, new DateTime(2024, 7, 17, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3177) },
                    { 3, 3, 2, null, new DateTime(2024, 7, 16, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3179) },
                    { 4, 4, 3, null, new DateTime(2024, 7, 15, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3181) },
                    { 5, 5, 4, null, new DateTime(2024, 7, 14, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3183) },
                    { 6, 6, 5, null, new DateTime(2024, 7, 13, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3185) },
                    { 7, 7, 6, null, new DateTime(2024, 7, 12, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3187) },
                    { 8, 8, 7, null, new DateTime(2024, 7, 11, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3189) },
                    { 9, 9, 8, null, new DateTime(2024, 7, 10, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3191) },
                    { 10, 10, 9, null, new DateTime(2024, 7, 9, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3194) },
                    { 11, 1, 10, null, new DateTime(2024, 7, 8, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3196) },
                    { 12, 2, 10, null, new DateTime(2024, 7, 8, 15, 35, 17, 582, DateTimeKind.Local).AddTicks(3198) }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OrderMenuItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
