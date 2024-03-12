using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialFilm.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Changed_parent_comment_name_property_at_comment_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_PreviousCommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PreviousCommentId",
                table: "Comments",
                newName: "ParentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PreviousCommentId",
                table: "Comments",
                newName: "IX_Comments_ParentCommentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentCommentId",
                table: "Comments",
                newName: "PreviousCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                newName: "IX_Comments_PreviousCommentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_PreviousCommentId",
                table: "Comments",
                column: "PreviousCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
