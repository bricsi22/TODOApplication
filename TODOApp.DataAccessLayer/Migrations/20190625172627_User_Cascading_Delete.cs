using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOApp.DataAccessLayer.Migrations
{
    public partial class User_Cascading_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_AspNetUsers_UserId",
                table: "TodoItem");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_AspNetUsers_UserId",
                table: "TodoItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_AspNetUsers_UserId",
                table: "TodoItem");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TodoItem",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_AspNetUsers_UserId",
                table: "TodoItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
