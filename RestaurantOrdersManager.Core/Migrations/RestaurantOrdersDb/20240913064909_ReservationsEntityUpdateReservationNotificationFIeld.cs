using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantOrdersManager.Core.Migrations.RestaurantOrdersDb
{
    /// <inheritdoc />
    public partial class ReservationsEntityUpdateReservationNotificationFIeld : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReservationNotificationSent",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 1,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 13, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(548));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 2,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 13, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 3,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 12, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 4,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 11, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 5,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 10, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 6,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 9, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 7,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 8, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 8,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 7, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 9,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 6, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 10,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 5, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 11,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 4, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 12,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 4, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(620));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 13, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 12, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 11, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 10, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 9, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 8, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(519));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 7, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 6, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 5, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 4, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "EndTime", "IsReservationNotificationSent", "StartTime", "TimeCreated" },
                values: new object[] { new DateTime(2024, 9, 13, 11, 49, 8, 607, DateTimeKind.Local).AddTicks(678), false, new DateTime(2024, 9, 13, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(677), new DateTime(2024, 9, 13, 6, 49, 8, 607, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 21,
                columns: new[] { "EndTime", "IsReservationNotificationSent", "StartTime", "TimeCreated" },
                values: new object[] { new DateTime(2024, 9, 13, 12, 49, 8, 607, DateTimeKind.Local).AddTicks(681), false, new DateTime(2024, 9, 13, 9, 49, 8, 607, DateTimeKind.Local).AddTicks(681), new DateTime(2024, 9, 13, 6, 49, 8, 607, DateTimeKind.Utc).AddTicks(680) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReservationNotificationSent",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 1,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9053));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 2,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 3,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 3, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 4,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 2, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 5,
                column: "ProcessStarted",
                value: new DateTime(2024, 9, 1, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 6,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 31, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9065));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 7,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 30, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 8,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 29, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 9,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 28, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 10,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 27, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9076));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 11,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.UpdateData(
                table: "OrderMenuItems",
                keyColumn: "OrderedMenuItemId",
                keyValue: 12,
                column: "ProcessStarted",
                value: new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 3, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 2, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "TimeCreated",
                value: new DateTime(2024, 9, 1, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 31, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 30, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 29, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 28, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 27, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10,
                column: "TimeCreated",
                value: new DateTime(2024, 8, 26, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime", "TimeCreated" },
                values: new object[] { new DateTime(2024, 9, 4, 17, 8, 56, 748, DateTimeKind.Local).AddTicks(9133), new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9132), new DateTime(2024, 9, 4, 12, 8, 56, 748, DateTimeKind.Utc).AddTicks(9132) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 21,
                columns: new[] { "EndTime", "StartTime", "TimeCreated" },
                values: new object[] { new DateTime(2024, 9, 4, 18, 8, 56, 748, DateTimeKind.Local).AddTicks(9137), new DateTime(2024, 9, 4, 15, 8, 56, 748, DateTimeKind.Local).AddTicks(9136), new DateTime(2024, 9, 4, 12, 8, 56, 748, DateTimeKind.Utc).AddTicks(9135) });
        }
    }
}
