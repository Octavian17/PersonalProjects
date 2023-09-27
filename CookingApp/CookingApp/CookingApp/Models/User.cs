using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Nickname { get; set; }

    }
}
