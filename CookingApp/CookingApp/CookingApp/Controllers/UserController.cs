using CookingApp.Models;
using CookingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class UserUpdated
        {
            public string Email { get; set; }
            public string Nickname { get; set; }
            public string CurrentPassword { get; set; }
            public string NewPassword { get; set; }
        };
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            var result = await userRepository.Register(user);
            return Ok(result);
        }


        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        { 
            var result = await userRepository.GetToken(model);
            if (string.IsNullOrEmpty(result.Token)) return NotFound(" " + result.Message);
            return Ok(result.Token);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UserUpdated user)
        {
            bool changePassword = true;
            bool changeNickname = true;
            if (user.NewPassword=="")
            {
                changePassword = false;
            }
            if (user.Nickname == "" && user.CurrentPassword=="")
            {
                changeNickname = false;
            }
         
            var result = await userRepository.UpdateUser(user.Email, user.Nickname, user.CurrentPassword, user.NewPassword, changePassword, changeNickname);
            
            return Ok(result);
            
            
        }
    }
}
    