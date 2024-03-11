using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialFilm.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<string>(type: "text", nullable: false),
                    Overview = table.Column<string>(type: "text", nullable: false),
                    PosterPath = table.Column<string>(type: "text", nullable: false),
                    BackdropPath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProfilePhotoURL = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmDetailGenres",
                columns: table => new
                {
                    FilmDetailId = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDetailGenres", x => new { x.FilmDetailId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_FilmDetailGenres_FilmDetails_FilmDetailId",
                        column: x => x.FilmDetailId,
                        principalTable: "FilmDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmDetailGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FilmId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedFilms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FilmId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedFilms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedFilms_FilmDetails_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedFilms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FriendId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    PreviousCommentId = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_PreviousCommentId",
                        column: x => x.PreviousCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostPhotos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostId = table.Column<string>(type: "text", nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPhotos_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { "10402", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9288), "Music", null },
                    { "10749", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9331), "Romance", null },
                    { "10751", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9207), "Family", null },
                    { "10752", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9450), "War", null },
                    { "10770", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9408), "TV Movie", null },
                    { "12", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9089), "Adventure", null },
                    { "14", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9231), "Fantasy", null },
                    { "16", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9107), "Animation", null },
                    { "18", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9187), "Drama", null },
                    { "27", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9268), "Horror", null },
                    { "28", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9032), "Action", null },
                    { "35", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9131), "Comedy", null },
                    { "36", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9249), "History", null },
                    { "37", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9469), "Western", null },
                    { "53", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9427), "Thriller", null },
                    { "80", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9150), "Crime", null },
                    { "878", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9389), "Science Fiction", null },
                    { "9648", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9307), "Mystery", null },
                    { "99", new DateTime(2024, 3, 10, 19, 51, 12, 16, DateTimeKind.Local).AddTicks(9168), "Documentary", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4de444e7-f5e1-4e43-be6b-badd43780c88", null, "Admin", "ADMIN" },
                    { "ca739d3c-f1ed-48ab-aa84-18be21d88601", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePhotoURL", "RefreshToken", "RefreshTokenExpires", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2", 0, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abdf22e2-0f63-40a8-b4a7-d7bb180ed6c4", new DateTime(2024, 3, 10, 19, 51, 12, 23, DateTimeKind.Local).AddTicks(8372), "admin@example.com", true, "Admin", "User", false, null, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEAGYFcaSqbaRGm4ywUGuer/l1YYMc+ziO4TCQtSh0bDjqRbNDdjon0aejPYFKm7OKQ==", null, false, null, null, null, "aee6d18f-368f-4a34-8de7-b7aad7ce24f9", false, null, "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4de444e7-f5e1-4e43-be6b-badd43780c88", "763ce2a2-d5e9-4b7f-b73a-23d6d912cbc2" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PreviousCommentId",
                table: "Comments",
                column: "PreviousCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmDetailGenres_GenreId",
                table: "FilmDetailGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmDetails_Name",
                table: "FilmDetails",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PostPhotos_PostId",
                table: "PostPhotos",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedFilms_FilmId",
                table: "SavedFilms",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedFilms_UserId_FilmId",
                table: "SavedFilms",
                columns: new[] { "UserId", "FilmId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_FriendId",
                table: "UserFriends",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FilmDetailGenres");

            migrationBuilder.DropTable(
                name: "PostPhotos");

            migrationBuilder.DropTable(
                name: "SavedFilms");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "FilmDetails");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
