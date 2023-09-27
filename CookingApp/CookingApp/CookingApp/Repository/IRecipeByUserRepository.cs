using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IRecipeByUserRepository
    {
        Task<IEnumerable<RecipeByUser>> Search(string name);
        Task<IEnumerable<RecipeByUser>> GetRecipes();
        Task<RecipeByUser> GetRecipe(int recipeId);
        Task<IEnumerable<RecipeByUser>> GetRecipesByUser(string email);
        Task<RecipeByUser> AddRecipe(RecipeByUser recipe, string email);
        Task<RecipeByUser> UpdateRecipe(RecipeByUser recipe);
        Task DeleteRecipe(int recipeId);
    }
}
