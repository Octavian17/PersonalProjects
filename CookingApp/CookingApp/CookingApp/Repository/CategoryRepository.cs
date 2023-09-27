using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var result = await appDbContext.Category.
               FirstOrDefaultAsync(a => a.CategoryId == categoryId);
            if (result != null)
            {
                appDbContext.Category.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await appDbContext.Category.ToListAsync();
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            return await appDbContext.Category.
               FirstOrDefaultAsync(a => a.CategoryId == categoryId);
        }

        public async Task<Category> PostCategory(Category category)
        {
            var result = await appDbContext.Category.AddAsync(category);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}

