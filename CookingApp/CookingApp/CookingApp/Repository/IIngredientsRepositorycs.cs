using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IIngredientsRepository
    {
        Task<Ingredients> GetIngredient(int ingredientId);
        Task<IEnumerable<Ingredients>> GetIngredients();
        Task<Ingredients> SaveIngredient(Ingredients ingredient);
        Task DeleteIngredient(int ingredientId);

    }
}