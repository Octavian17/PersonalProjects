using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingApp.Migrations
{
    public partial class seedRecipeWithMyRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "AuthorId", "CookingTime", "Description", "Image", "Kcal", "Name", "PreparationTime" },
                values: new object[] { 3, 2, "200 min", "cu ce vreau eu", "C:/Users/presc/OneDrive/Desktop/placinta-cu-mere.jpg", 100.0, "Prajitura casei", "200 h" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "RecipeId",
                keyValue: 3);
        }
    }
}
