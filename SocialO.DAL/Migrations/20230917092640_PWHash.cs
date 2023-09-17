using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialO.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PWHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(9954),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 592, DateTimeKind.Local).AddTicks(8293),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 589, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(3810),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 588, DateTimeKind.Local).AddTicks(7408),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 581, DateTimeKind.Local).AddTicks(8933),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 464, DateTimeKind.Local).AddTicks(7150));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(7280),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(7929),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 592, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(8439),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 589, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(4082),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(5525),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 588, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 464, DateTimeKind.Local).AddTicks(7150),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 581, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountStatus", "DataRegistered", "Email", "Password", "RefreshToken", "RefreshTokenEndDate", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, "Active", new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3224), "admin@socialo.com", "admin", null, null, "Admin", "admin" },
                    { 2, "Active", new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3233), "user1@socialo.com", "user1", null, null, "User", "user1" },
                    { 3, "Active", new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3235), "user2@socialo.com", "user2", null, null, "User", "user2" }
                });

            migrationBuilder.InsertData(
                table: "FollowerRelationships",
                columns: new[] { "Id", "DateFollowed", "FollowerId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1846), 3, 1 },
                    { 2, new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1854), 3, 2 },
                    { 3, new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1855), 2, 1 },
                    { 4, new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1857), 1, 3 }
                });
        }
    }
}
