using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingApp.Migrations
{
    public partial class updateRecipeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_User_UserId",
                table: "UserRecipe");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserRecipe",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_AspNetUsers_UserId",
                table: "UserRecipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_AspNetUsers_UserId",
                table: "UserRecipe");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserRecipe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_User_UserId",
                table: "UserRecipe",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
