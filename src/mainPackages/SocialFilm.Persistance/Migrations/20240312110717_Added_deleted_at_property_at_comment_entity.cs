using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialFilm.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Added_deleted_at_property_at_comment_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Comments",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10402",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10749",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1123));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10751",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10752",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10770",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "35",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "36",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(959));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "37",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "53",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "80",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(740));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "878",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9648",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(1084));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "99",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 14, 7, 17, 182, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "eacc516b-339f-4da2-b5ad-cba2b6d032e7", new DateTime(2024, 3, 12, 14, 7, 17, 203, DateTimeKind.Local).AddTicks(9701), "AQAAAAIAAYagAAAAEMMy3w8Os032x4LBHcqmESOI9BeE5xjtOIaSfMOi4oEbm+Au12AikwjNgVg+69eVoA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10402",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10749",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2454));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10751",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10752",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10770",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2568));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2168));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "35",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "36",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "37",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "53",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "80",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "878",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9648",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "99",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 11, 47, 50, 310, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "a77709dc-683d-447c-b05c-1a2b7f0f5b1f", new DateTime(2024, 3, 12, 11, 47, 50, 332, DateTimeKind.Local).AddTicks(8350), "AQAAAAIAAYagAAAAEM46decASiV4eDaa0eewML8GzJjK7fNQ/D2alMHfcbXE/hTcW5MLXG30pwsjBeGbmw==" });
        }
    }
}
