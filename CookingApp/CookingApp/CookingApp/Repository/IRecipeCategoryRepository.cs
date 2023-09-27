using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IRecipeCategoryRepository
    {
        Task<RecipeCategory> GetCategory(int recipeId);
        Task<IEnumerable<RecipeCategory>> GetRecipesByCategory(int id);
        Task<RecipeCategory> AddRecipeCategory(RecipeCategory recipeCategory);
        Task<IEnumerable<RecipeCategory>> GetRecipeCategory();
    }
}