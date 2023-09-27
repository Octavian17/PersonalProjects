using CookingApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class UserRecipeRepository : IUserRecipeRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public UserRecipeRepository(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        public async Task<string> AddUserRecipe(int recipeId, string email)
        {
            var recipe= await appDbContext.Recipe.
                Include(r => r.Author).
                FirstOrDefaultAsync(r => r.RecipeId == recipeId);
            var user = await userManager.FindByEmailAsync(email);
            UserRecipe userRecipe = new();
            userRecipe.User = user;
            userRecipe.Recipe = recipe;

            var result = await appDbContext.UserRecipe.AddAsync(userRecipe);
            await appDbContext.SaveChangesAsync();
            if (result != null)
            {
                return "Succes!";
            }
            else
            {
                return "Error!";
            }
        }

        public async Task<string> DeleteUserRecipe(int recipeId, string email)
        {
            var result = await appDbContext.UserRecipe.
               FirstOrDefaultAsync(r => r.RecipeId == recipeId && r.User.Email==email);
            //result = await appDbContext.UserRecipe.
            //   FirstOrDefaultAsync(u => u.User.Email == email);
            if (result != null)
            {
                appDbContext.UserRecipe.Remove(result);
                await appDbContext.SaveChangesAsync();
                return "Succes!";
            }
            else
            {
                return "Error!";
            }
        }

        public async Task<IEnumerable<UserRecipe>> GetUserRecipes()
        {
            return await appDbContext.UserRecipe.Include(r => r.Recipe).Include(u=>u.User).ToListAsync();
        }

        public async Task<IEnumerable<UserRecipe>> GetRecipesByUser(string email)
        {
            IQueryable<UserRecipe> query = appDbContext.UserRecipe;
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(r => r.User.Email.Equals(email)).Include(r => r.Recipe);
            }
            return await query.ToListAsync();
        }

        public async Task<string> CheckIfRecipeExists(int recipeId)
        {
            IQueryable<UserRecipe> query = appDbContext.UserRecipe;

            IQueryable<UserRecipe> query1 = query.Where(r => r.RecipeId==recipeId);
            var result = query1.ToArray();
            var list = result.ToList();
            if (list.Count()>0)
            {
                return "True";
            }
            else
            {
                return "False";
            }
            
        }
    }      
}

