using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IUserRecipeRepository
    {
        Task<IEnumerable<UserRecipe>> GetRecipesByUser(string email);
        Task<string> CheckIfRecipeExists(int recipeId);
        Task<string> AddUserRecipe(int recipeId, string email);
        Task<string> DeleteUserRecipe(int recipeId, string email);
        Task<IEnumerable<UserRecipe>> GetUserRecipes();
    }
}