
using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class Ingredients
    {   
        public int IngredientsId { get; set; } 
        public string Name { get; set; } 
        public string Amount { get; set; } 
        public string Unit { get; set; }         
    }
}