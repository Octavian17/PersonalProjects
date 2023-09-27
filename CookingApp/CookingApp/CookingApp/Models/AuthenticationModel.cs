using System;
using System.ComponentModel.DataAnnotations;

namespace CookingApp.Models
{
    public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }     
        public string Email { get; set; }
        public string Token { get; set; }     
    }
}
