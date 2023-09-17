using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialO.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PWHash2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 186, DateTimeKind.Local).AddTicks(4140),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 188, DateTimeKind.Local).AddTicks(681),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 592, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(8865),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 589, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 185, DateTimeKind.Local).AddTicks(8180),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(3516),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 588, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 178, DateTimeKind.Local).AddTicks(7435),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 581, DateTimeKind.Local).AddTicks(8933));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(9954),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 186, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 592, DateTimeKind.Local).AddTicks(8293),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 188, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 589, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 590, DateTimeKind.Local).AddTicks(3810),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 185, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 588, DateTimeKind.Local).AddTicks(7408),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 12, 26, 40, 581, DateTimeKind.Local).AddTicks(8933),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 178, DateTimeKind.Local).AddTicks(7435));
        }
    }
}
