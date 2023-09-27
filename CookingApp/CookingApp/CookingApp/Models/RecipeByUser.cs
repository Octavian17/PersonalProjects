using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class RecipeByUser
    {
        public int RecipeByUserId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Kcal { get; set; }

        public string PreparationTime { get; set; }

        public string CookingTime { get; set; }

        public string UserId { get; set; }

        public string Ingredients { get; set; }

        public ApplicationUser User { get; set; }

    }
}
