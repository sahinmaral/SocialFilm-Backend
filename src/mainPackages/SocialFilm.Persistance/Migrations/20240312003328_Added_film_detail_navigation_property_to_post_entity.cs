using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialFilm.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Added_film_detail_navigation_property_to_post_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10402",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10749",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9973));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10751",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9845));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10752",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 853, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10770",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 853, DateTimeKind.Local).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9865));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "35",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "36",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "37",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 853, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "53",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 853, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "80",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "878",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9648",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "99",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 12, 3, 33, 27, 852, DateTimeKind.Local).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "07e5daae-c892-4c7c-a7db-f48a69c73fc9", new DateTime(2024, 3, 12, 3, 33, 27, 860, DateTimeKind.Local).AddTicks(5104), "AQAAAAIAAYagAAAAEIJpncCTKL5jsXcqSrMBU3yZIRmCwZxhlf+j9tONkxQvKXXHxg8KO3sNUm0aZVl3vA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_FilmId",
                table: "Posts",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_FilmDetails_FilmId",
                table: "Posts",
                column: "FilmId",
                principalTable: "FilmDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_FilmDetails_FilmId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_FilmId",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10402",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9288));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10749",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10751",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10752",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "10770",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9408));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "12",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "14",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9231));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "16",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9107));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "18",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "27",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "28",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "35",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "36",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "37",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "53",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9427));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "80",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "878",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "9648",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: "99",
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "abdf22e2-0f63-40a8-b4a7-d7bb180ed6c4", new DateTime(2024, 3, 10, 19, 51, 12, 23, DateTimeKind.Local).AddTicks(8372), "AQAAAAIAAYagAAAAEAGYFcaSqbaRGm4ywUGuer/l1YYMc+ziO4TCQtSh0bDjqRbNDdjon0aejPYFKm7OKQ==" });
        }
    }
}
