using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly AppDbContext appDbContext;
        public IngredientsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

       
        public async Task<Ingredients> GetIngredient(int ingredientId)
        {
            return await appDbContext.Ingredients.
                FirstOrDefaultAsync(r => r.IngredientsId == ingredientId);
        }

        public async Task<IEnumerable<Ingredients>> GetIngredients()
        {
            return await appDbContext.Ingredients.ToListAsync();
        }

        public async Task<Ingredients> SaveIngredient(Ingredients ingredient)
        {
            var result = await appDbContext.Ingredients.AddAsync(ingredient);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteIngredient(int ingredientId)
        {
            var result = await appDbContext.Ingredients.
               FirstOrDefaultAsync(r => r.IngredientsId == ingredientId);
            if (result != null)
            {
                appDbContext.Ingredients.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
