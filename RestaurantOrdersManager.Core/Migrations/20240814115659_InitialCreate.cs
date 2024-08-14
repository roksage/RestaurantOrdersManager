using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantOrdersManager.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { 1, 1, 1, new DateTime(2024, 8, 14, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1570), null },
                    { 2, 2, 1, new DateTime(2024, 8, 13, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1574), null },
                    { 3, 3, 1, new DateTime(2024, 8, 12, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1579), null },
                    { 4, 1, 2, new DateTime(2024, 8, 11, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1581), null },
                    { 5, 2, 2, new DateTime(2024, 8, 10, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1583), null },
                    { 6, 3, 3, new DateTime(2024, 8, 9, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1585), null },
                    { 7, 1, 3, new DateTime(2024, 8, 8, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1587), null },
                    { 8, 2, 4, new DateTime(2024, 8, 7, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1591), null },
                    { 9, 3, 4, new DateTime(2024, 8, 6, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1593), null },
                    { 10, 1, 5, new DateTime(2024, 8, 5, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1595), null }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Email", "EndTime", "PeopleCount", "ReservationInfo", "ReservationStatus", "StartTime", "TableId", "TimeCreated", "VerificationCode" },
                values: new object[,]
                {
                    { 1, "test@email.com", new DateTime(2024, 8, 14, 16, 56, 58, 677, DateTimeKind.Local).AddTicks(1687), 0, "Test Reservation", 1, new DateTime(2024, 8, 14, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1686), 2, new DateTime(2024, 8, 14, 11, 56, 58, 677, DateTimeKind.Utc).AddTicks(1685), "ABCD" },
                    { 21, "test@email.com", new DateTime(2024, 8, 14, 17, 56, 58, 677, DateTimeKind.Local).AddTicks(1690), 0, "Test Reservation2", 1, new DateTime(2024, 8, 14, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1689), 2, new DateTime(2024, 8, 14, 11, 56, 58, 677, DateTimeKind.Utc).AddTicks(1689), "ABCDE" }
                });

            migrationBuilder.InsertData(
                table: "OrderMenuItems",
                columns: new[] { "OrderedMenuItemId", "MenuItemId", "OrderId", "ProcessCompleted", "ProcessStarted" },
                values: new object[,]
                {
                    { 1, 1, 1, null, new DateTime(2024, 8, 14, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1615) },
                    { 2, 2, 1, null, new DateTime(2024, 8, 14, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1617) },
                    { 3, 3, 2, null, new DateTime(2024, 8, 13, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1619) },
                    { 4, 4, 3, null, new DateTime(2024, 8, 12, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1621) },
                    { 5, 5, 4, null, new DateTime(2024, 8, 11, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1623) },
                    { 6, 6, 5, null, new DateTime(2024, 8, 10, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1625) },
                    { 7, 7, 6, null, new DateTime(2024, 8, 9, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1627) },
                    { 8, 8, 7, null, new DateTime(2024, 8, 8, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1629) },
                    { 9, 9, 8, null, new DateTime(2024, 8, 7, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1631) },
                    { 10, 10, 9, null, new DateTime(2024, 8, 6, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1633) },
                    { 11, 1, 10, null, new DateTime(2024, 8, 5, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1635) },
                    { 12, 2, 10, null, new DateTime(2024, 8, 5, 14, 56, 58, 677, DateTimeKind.Local).AddTicks(1637) }
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
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
