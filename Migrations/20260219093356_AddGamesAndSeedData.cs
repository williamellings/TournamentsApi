using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TournamentsApi.Migrations
{
    /// <inheritdoc />
    public partial class AddGamesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "Id", "Date", "Description", "MaxPlayers", "Title" },
                values: new object[] { 1, new DateTime(2026, 3, 19, 10, 33, 55, 474, DateTimeKind.Local).AddTicks(7737), "Biggest Esport event in the world.", 64, "GG Masters" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Time", "Title", "TournamentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 19, 20, 33, 55, 477, DateTimeKind.Local).AddTicks(1206), "Quarter finals A", 1 },
                    { 2, new DateTime(2026, 3, 19, 22, 33, 55, 477, DateTimeKind.Local).AddTicks(1517), "Quarter finals B", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TournamentId",
                table: "Games",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
