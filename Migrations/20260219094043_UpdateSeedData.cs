using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentsApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2026, 3, 19, 20, 40, 42, 538, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2026, 3, 19, 22, 40, 42, 538, DateTimeKind.Local).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2026, 3, 19, 10, 40, 42, 535, DateTimeKind.Local).AddTicks(9675));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2026, 3, 19, 20, 33, 55, 477, DateTimeKind.Local).AddTicks(1206));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2026, 3, 19, 22, 33, 55, 477, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2026, 3, 19, 10, 33, 55, 474, DateTimeKind.Local).AddTicks(7737));
        }
    }
}
