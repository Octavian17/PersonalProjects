using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> Search(string name);
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Recipe> GetRecipe(int recipeId);
        Task<IEnumerable<Recipe>> GetRecipesByAuthor(string firstName, string lastName);
        Task<Recipe> AddRecipe(Recipe recipe);
        Task<Recipe> UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int recipeId);
    }
}
