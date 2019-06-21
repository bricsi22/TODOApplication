using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOApp.DataAccessLayer.Migrations
{
    public partial class DeadLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeadLine",
                table: "TodoItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeadLine",
                table: "TodoItem",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
