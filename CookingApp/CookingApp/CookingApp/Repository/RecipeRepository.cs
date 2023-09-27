using CookingApp.Models;
using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly AppDbContext appDbContext;
        public RecipeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Recipe> AddRecipe(Recipe recipe)
        {
            if (recipe.Author != null)
            {
                appDbContext.Entry(recipe.Author).State = EntityState.Unchanged;
            }
            var result = await appDbContext.Recipe.AddAsync(recipe);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var result = await appDbContext.Recipe.
               FirstOrDefaultAsync(r => r.RecipeId == recipeId);
            if (result != null)
            {
                appDbContext.Recipe.Remove(result);
                await appDbContext.SaveChangesAsync();
            }   
        }

        public async Task<Recipe> GetRecipe(int recipeId)
        {
            return await appDbContext.Recipe.
                Include(r => r.Author).
                FirstOrDefaultAsync(r => r.RecipeId == recipeId);
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await appDbContext.Recipe.Include(a=>a.Author).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByAuthor(string firstName, string lastName)
        {
            IQueryable<Recipe> query = appDbContext.Recipe;
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(r => r.Author.FirstName.Equals(firstName) && r.Author.LastName.Equals(lastName));

            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> Search(string name)
        {
            IQueryable<Recipe> query = appDbContext.Recipe;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            var result = await appDbContext.Recipe.FirstOrDefaultAsync
                (r=> r.RecipeId == recipe.RecipeId);
            if (result != null)
            {
                result.Name = recipe.Name;
                result.Description = recipe.Description;
                if (recipe.Author != null)
                {
                    if (recipe.Author.AuthorId != 0)
                    {
                        result.Author.AuthorId = recipe.Author.AuthorId;
                    }
                }

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}