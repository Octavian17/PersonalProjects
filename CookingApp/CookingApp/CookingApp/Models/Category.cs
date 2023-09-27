using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        
    }
}
