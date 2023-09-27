using CookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetCategories();
        Task<Category> PostCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<Category> GetCategory(int categoryId);
    }
}