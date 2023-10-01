using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnCreatedToLoggersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_AspNetUsers_AppUserId",
                table: "Logger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logger",
                table: "Logger");

            migrationBuilder.RenameTable(
                name: "Logger",
                newName: "Loggers");

            migrationBuilder.RenameIndex(
                name: "IX_Logger_AppUserId",
                table: "Loggers",
                newName: "IX_Loggers_AppUserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Loggers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loggers",
                table: "Loggers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loggers_AspNetUsers_AppUserId",
                table: "Loggers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loggers_AspNetUsers_AppUserId",
                table: "Loggers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loggers",
                table: "Loggers");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Loggers");

            migrationBuilder.RenameTable(
                name: "Loggers",
                newName: "Logger");

            migrationBuilder.RenameIndex(
                name: "IX_Loggers_AppUserId",
                table: "Logger",
                newName: "IX_Logger_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logger",
                table: "Logger",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_AspNetUsers_AppUserId",
                table: "Logger",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
