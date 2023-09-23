using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialO.DAL.Migrations
{
    /// <inheritdoc />
    public partial class authorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 727, DateTimeKind.Local).AddTicks(1527),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 186, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 728, DateTimeKind.Local).AddTicks(1959),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 188, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 726, DateTimeKind.Local).AddTicks(2570),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 726, DateTimeKind.Local).AddTicks(8245),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 185, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 726, DateTimeKind.Local).AddTicks(195),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(3516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 723, DateTimeKind.Local).AddTicks(1195),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 178, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistered",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 186, DateTimeKind.Local).AddTicks(4140),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 727, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "UserProfiles",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 188, DateTimeKind.Local).AddTicks(681),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 728, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(8865),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 726, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFavorited",
                table: "PostFavorites",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 185, DateTimeKind.Local).AddTicks(8180),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 726, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCommented",
                table: "PostComments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 184, DateTimeKind.Local).AddTicks(3516),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 726, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFollowed",
                table: "FollowerRelationships",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 17, 14, 30, 12, 178, DateTimeKind.Local).AddTicks(7435),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 9, 22, 16, 14, 37, 723, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
