using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class RecipeCategory
    {
        public int RecipeCategoryId { get; set; }

        public int CategoryId { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public Category Category { get; set; }
    }
}
