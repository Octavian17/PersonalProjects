using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IRecipeIngredientRepository
    {
        Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipe(int id);
        Task<List<Recipe>> GetRecipesByIngredients(string[] ingredients);
        Task<RecipeIngredient> AddRecipeIngredient(RecipeIngredient recipeIngredient);
        Task<RecipeIngredient> GetRecipeIngredient(int recipeIngredientId);
        Task<IEnumerable<RecipeIngredient>> GetRecipeIngredients();
        Task DeleteRecipeIngredient(int recipeIngredientId);
    }
}