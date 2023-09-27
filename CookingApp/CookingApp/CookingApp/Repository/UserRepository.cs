using CookingApp.Repository;
using CookingApp.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AppDbContext appDbContext;
        private readonly JWT jwt;
        public UserRepository(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, IOptions<JWT> jwt)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
            this.jwt = jwt.Value;
        }

       

        public async Task<string> Register(User user)
        {
            var user1 = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.Nickname  
            };
            var userWithSameEmail = await userManager.FindByEmailAsync(user.Email);
            if (userWithSameEmail == null)
            {
                var result = await userManager.CreateAsync(user1, user.Password);
                if (result.Succeeded)
                {
                    //return "User registered successfully with nickname "+ user.Nickname;
                    return "success";
                }
                else
                {
                    string descr = "";
                    if (result.Errors.Any())
                    {
                        foreach (var item in result.Errors)
                        {
                            descr += item.Description;
                        }
                    }
                    //return "Error(s), registering user : "+descr;
                    return "error";
                }
            }
            else
            {
                //return "Email "+ user.Email+" is already registered.";
                return "error";
            }
        }     

        public async Task<AuthenticationModel> GetToken(TokenRequestModel model)
        {
            var authenticationModel = new AuthenticationModel();
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                authenticationModel.IsAuthenticated = false;
                authenticationModel.Message = "Niciun cont inregistrat cu email-ul "+model.Email;
                return authenticationModel;
            }
            if (await userManager.CheckPasswordAsync(user, model.Password))
            {
                authenticationModel.IsAuthenticated = true;
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                authenticationModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                authenticationModel.Email = user.Email;
                authenticationModel.Username = user.UserName;
                return authenticationModel;
            }
            authenticationModel.IsAuthenticated = false;
            authenticationModel.Message = "Incorrect password for user "+ user.Email;
            return authenticationModel;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
    }.Union(userClaims).Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(issuer: jwt.Issuer, audience: jwt.Audience, claims: claims, expires: DateTime.UtcNow.AddMinutes(jwt.DurationInMinutes), signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task<string> UpdateUser(string email, string nickname, string currentPassword, string newPassword, bool changePassword, bool changeNickname)
        {
            string result = null;
            // Get the existing student from the db
            var user1 = await userManager.FindByEmailAsync(email);
            if(userManager.CheckPasswordAsync(user1,currentPassword).Result==false)
            {
                result += "Incorrect password!\n";
                return result;
            }
            
           
            // Update it with the values from the view model
            if (user1!=null)
            {
                if (changePassword == true)
                {
                    var identity=await userManager.ChangePasswordAsync(user1, currentPassword, newPassword);
                    if(identity.Succeeded)
                    {
                        result += "Password has been changed!\n";
                    }
                    else
                    {
                        result += "Incorrect password!\n";
                        if(changeNickname==false)
                        {
                            return result;
                        }
                    }
                }
                if (changeNickname == true)
                {
                    user1.UserName = nickname;
                }
            }
            else
            {
                result += "User does not exist!";
                return result;
            }
           
            if(changePassword==false&&changeNickname==false)
            {
                return result;
            }
            // Apply the changes if any to the db           
            var identityUpdate=await userManager.UpdateAsync(user1);
            if(identityUpdate.Succeeded)
            {
                result += "Nickname updated!";
            }
           
         
            return result;
        }
    }
}

