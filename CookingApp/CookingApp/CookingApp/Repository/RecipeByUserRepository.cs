using CookingApp.Models;
using CookingApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class RecipeByUserRepository:IRecipeByUserRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public RecipeByUserRepository(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        public async Task<RecipeByUser> AddRecipe(RecipeByUser recipe, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            recipe.User = user;
            var result = await appDbContext.RecipeByUser.AddAsync(recipe);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var result = await appDbContext.RecipeByUser.
              FirstOrDefaultAsync(r => r.RecipeByUserId == recipeId);
            if (result != null)
            {
                appDbContext.RecipeByUser.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<RecipeByUser> GetRecipe(int recipeId)
        {
            return await appDbContext.RecipeByUser.
                Include(r => r.User).
                FirstOrDefaultAsync(r => r.RecipeByUserId == recipeId);
        }

        public async Task<IEnumerable<RecipeByUser>> GetRecipes()
        {
            return await appDbContext.RecipeByUser.Include(a => a.User).ToListAsync();
        }

        public async Task<IEnumerable<RecipeByUser>> GetRecipesByUser(string email)
        {
            IQueryable<RecipeByUser> query = appDbContext.RecipeByUser;
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(r => r.User.Email.Equals(email));

            }
            return await query.Include(r => r.User).ToListAsync();
        }

        public async Task<IEnumerable<RecipeByUser>> Search(string name)
        {
            IQueryable<RecipeByUser> query = appDbContext.RecipeByUser;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.Include(a => a.User).ToListAsync();
        }

        public async Task<RecipeByUser> UpdateRecipe(RecipeByUser recipe)
        {
            var result = await appDbContext.RecipeByUser.FirstOrDefaultAsync
                (r => r.RecipeByUserId == recipe.RecipeByUserId);
            if (result != null)
            {
                result.Name = recipe.Name;
                result.Description = recipe.Description;
                result.CookingTime = recipe.CookingTime;
                result.PreparationTime = recipe.PreparationTime;
                result.Image = recipe.Image;
                result.Kcal = recipe.Kcal;
                result.Ingredients = recipe.Ingredients;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
