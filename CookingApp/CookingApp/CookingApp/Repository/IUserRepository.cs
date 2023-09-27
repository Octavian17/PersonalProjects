using CookingApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public interface IUserRepository
    {
        Task<AuthenticationModel> GetToken(TokenRequestModel model);
        Task<string> Register(User user);
        Task<string> UpdateUser(string email, string nickname, string currentPassword, string newPassword, bool changePassword, bool changeNickname);
    }
}
