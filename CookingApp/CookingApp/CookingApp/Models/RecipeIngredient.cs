

namespace CookingApp.Models
{
    public class RecipeIngredient
    {
        public int RecipeIngredientId { get; set; }
        
        public int IngredientsId { get; set; }

        public int RecipeId { get; set; }

        public string Quantity { get; set; }

        public Recipe Recipe { get; set; }

        public Ingredients Ingredients { get; set; }
    }
}
