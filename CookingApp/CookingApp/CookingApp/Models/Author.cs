using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
