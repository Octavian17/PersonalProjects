using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Kcal { get; set; }

        public string PreparationTime { get; set; }

        public string CookingTime { get; set; }

        public int? AuthorId { get; set; }

        public Author Author { get; set; }

    }
}
