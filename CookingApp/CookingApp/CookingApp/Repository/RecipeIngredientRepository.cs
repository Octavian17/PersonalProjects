using CookingApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly AppDbContext appDbContext;
        public RecipeIngredientRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<RecipeIngredient> AddRecipeIngredient(RecipeIngredient recipeIngredient)
        {            
            var result = await appDbContext.RecipeIngredient.AddAsync(recipeIngredient);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipe(int id)
        {
            IQueryable<RecipeIngredient> query1 = appDbContext.RecipeIngredient;

            query1 = query1.Where(r => r.RecipeId == id);
           
            return await query1.Include(r => r.Ingredients).ToListAsync();
        }

        public async Task<RecipeIngredient> GetRecipeIngredient(int recipeIngredientId)
        {
            return await appDbContext.RecipeIngredient.
                Include(r => r.Recipe).Include(i=>i.Ingredients).
                FirstOrDefaultAsync(r => r.RecipeIngredientId == recipeIngredientId);
        }

        public async Task<IEnumerable<RecipeIngredient>> GetRecipeIngredients()
        {
            return await appDbContext.RecipeIngredient.Include(r => r.Recipe).Include(i=>i.Ingredients).ToListAsync();
        }

        public async Task<List<Recipe>> GetRecipesByIngredients(string[] ingredients)
        {
            IQueryable<RecipeIngredient> query = appDbContext.RecipeIngredient;
            IEnumerable<Recipe> recipes = appDbContext.Recipe;
            List<string> ingredientsList = ingredients[0].Split(',').ToList();           
            List<Recipe> search = new List<Recipe>();

            foreach (var recipe in recipes.ToList())
            {
                bool exists = true;
                foreach(var ingredient in ingredientsList)
                {
                    var checkIfExist = query.Where(r => r.Recipe == recipe).Where(i => i.Ingredients.Name == ingredient);
                    if (!checkIfExist.ToList().Any())
                    {
                        exists = false;
                        break;                       
                    }                    
                }
                if (exists == true)
                {
                    search.Add(recipe);
                    //selectedRecipes = selectedRecipes.Concat(new[] { recipe });
                }
            }
            //var queryable = search.AsQueryable();
            return search;
            //return await selectedRecipes.ToListAsync();
        }

        public async Task DeleteRecipeIngredient(int recipeIngredientId)
        {
            var result = await appDbContext.RecipeIngredient.
               FirstOrDefaultAsync(r => r.RecipeIngredientId == recipeIngredientId);
            if (result != null)
            {
                appDbContext.RecipeIngredient.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }      
}

