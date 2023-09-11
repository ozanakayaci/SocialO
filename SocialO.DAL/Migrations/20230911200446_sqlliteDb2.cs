using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialO.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sqlliteDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(7280),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 298, DateTimeKind.Local).AddTicks(7921));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenEndDate",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(7929),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(8439),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(8113));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(4082),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 298, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(5525),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 464, DateTimeKind.Local).AddTicks(7150),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 294, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataRegistered", "RefreshToken", "RefreshTokenEndDate" },
                values: new object[] { new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3224), null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataRegistered", "RefreshToken", "RefreshTokenEndDate" },
                values: new object[] { new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3233), null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataRegistered", "RefreshToken", "RefreshTokenEndDate" },
                values: new object[] { new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(3235), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenEndDate",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 298, DateTimeKind.Local).AddTicks(7921),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(6190),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 469, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(8113),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 298, DateTimeKind.Local).AddTicks(4841),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 468, DateTimeKind.Local).AddTicks(4082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(5788),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 467, DateTimeKind.Local).AddTicks(5525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 11, 16, 29, 52, 294, DateTimeKind.Local).AddTicks(8867),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 11, 23, 4, 46, 464, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "FollowerRelationships",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateFollowed",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 297, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataRegistered",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataRegistered",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(3236));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataRegistered",
                value: new DateTime(2023, 9, 11, 16, 29, 52, 299, DateTimeKind.Local).AddTicks(3238));
        }
    }
}
