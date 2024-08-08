using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantOrdersManager.Core.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 1,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 8, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 2,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 8, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 3,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 7, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 4,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 6, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 5,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 5, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 6,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 4, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 7,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 3, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8194));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 8,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 2, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8197));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 9,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 1, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 10,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 31, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8221));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 11,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 30, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 12,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 30, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 8, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 7, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 6, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 5, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 4, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 3, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 2, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 1, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 31, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8161));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 30, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "EndTime", "ReservationInfo", "StartTime", "TableId" },
                values: new object[] { 1, new DateTime(2024, 8, 8, 17, 33, 52, 166, DateTimeKind.Local).AddTicks(8274), "Test Reservation", new DateTime(2024, 8, 8, 15, 33, 52, 166, DateTimeKind.Local).AddTicks(8273), 2 });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Seats", "Status", "TableName" },
                values: new object[] { 6, 2, 0, "Table 6" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 1,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 24, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 2,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 24, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 3,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 23, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 4,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 22, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6380));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 5,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 21, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 6,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 20, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 7,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 19, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 8,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 18, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6390));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 9,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 17, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6392));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 10,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 16, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 11,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 15, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 12,
                column: "ProcessStarted",
                value: new DateTime(2024, 7, 15, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6398));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 24, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 23, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6327));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 22, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 21, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6335));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 20, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6337));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 19, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 18, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6343));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 17, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 16, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                column: "TimeCreated",
                value: new DateTime(2024, 7, 15, 16, 57, 51, 765, DateTimeKind.Local).AddTicks(6349));
        }
    }
}
