using CookingApp.Models;
using CookingApp.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class UserRecipeController : Controller
    {
        private readonly IUserRecipeRepository urRepo = null;

        public UserRecipeController(IUserRecipeRepository urRepo)
        {
            this.urRepo = urRepo;
        }

        [HttpPost("CreateUserRecipe/{email}/{recipeId}")]
        public async Task<ActionResult> AddUserRecipe(string email, int recipeId)
        {
            var result = await urRepo.AddUserRecipe(recipeId, email);
            return Ok(result);
        }

        [HttpDelete("DeleteUserRecipe/{email}/{recipeId}")]
        public async Task<ActionResult> DeleteUserRecipe(string email, int recipeId)
        {
            var result = await urRepo.DeleteUserRecipe(recipeId, email);
            return Ok(result);
        }

        [HttpGet("GetUserRecipes")]
        public async Task<ActionResult> GetUserRecipes()
        {
            try
            {
                return Ok(await urRepo.GetUserRecipes());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

       
        [HttpGet("GetRecipesByUser/{email}")]
        public async Task<ActionResult> GetRecipesByUser(string email)
        {
            try
            {
                return Ok(await urRepo.GetRecipesByUser(email));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("CheckIfRecipeExists/{recipeId}")]
        public async Task<ActionResult> CheckIfRecipesExists(int recipeId)
        {
            try
            {
                return Ok(await urRepo.CheckIfRecipeExists(recipeId));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
    }
}
