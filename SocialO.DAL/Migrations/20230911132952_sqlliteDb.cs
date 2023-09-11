using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialO.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sqlliteDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DataRegistered = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 298, DateTimeKind.Local).AddTicks(7921)),
                    UserType = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "User"),
                    AccountStatus = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "Active")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowerRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateFollowed = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 294, DateTimeKind.Local).AddTicks(8867)),
                    FollowerId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowerRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowerRelationships_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowerRelationships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(8113)),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Gender = table.Column<char>(type: "TEXT", maxLength: 1, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(6190)),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DateCommented = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(5788)),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateFavorited = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 298, DateTimeKind.Local).AddTicks(4841)),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostFavorites_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountStatus", "DataRegistered", "Email", "Password", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, "Active", new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(3230), "admin@socialo.com", "admin", "Admin", "admin" },
                    { 2, "Active", new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(3236), "user1@socialo.com", "user1", "User", "user1" },
                    { 3, "Active", new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(3238), "user2@socialo.com", "user2", "User", "user2" }
                });

            migrationBuilder.InsertData(
                table: "FollowerRelationships",
                columns: new[] { "Id", "DateFollowed", "FollowerId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2526), 3, 1 },
                    { 2, new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2536), 3, 2 },
                    { 3, new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2538), 2, 1 },
                    { 4, new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2539), 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowerRelationships_FollowerId",
                table: "FollowerRelationships",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowerRelationships_UserId",
                table: "FollowerRelationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostId",
                table: "PostComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_UserId",
                table: "PostComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostFavorites_PostId",
                table: "PostFavorites",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostFavorites_UserId",
                table: "PostFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowerRelationships");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostFavorites");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
