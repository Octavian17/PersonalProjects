

namespace CookingApp.Models
{
    public class UserRecipe
    {
        public int UserRecipeId { get; set; }

        public string UserId { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public ApplicationUser User { get; set; }
    }
}
