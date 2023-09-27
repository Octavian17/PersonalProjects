using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class RecipeCategoryRepository : IRecipeCategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public RecipeCategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<RecipeCategory> AddRecipeCategory(RecipeCategory recipeCategory)
        {
            var result = await appDbContext.RecipeCategory.AddAsync(recipeCategory);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RecipeCategory> GetCategory(int recipeId)
        {
            return await appDbContext.RecipeCategory.
                Include(c => c.Category).
                FirstOrDefaultAsync(r => r.RecipeId == recipeId);
        }

        public async Task<IEnumerable<RecipeCategory>> GetRecipeCategory()
        {
            return await appDbContext.RecipeCategory.Include(r => r.Recipe).Include(i => i.Category).ToListAsync();
        }

        public async Task<IEnumerable<RecipeCategory>> GetRecipesByCategory(int id)
        {
            IQueryable<RecipeCategory> query1 = appDbContext.RecipeCategory;

            query1 = query1.Where(c => c.CategoryId==id);
            
           
            return await query1.Include(r=>r.Recipe).ToListAsync();
        }
    }
}

