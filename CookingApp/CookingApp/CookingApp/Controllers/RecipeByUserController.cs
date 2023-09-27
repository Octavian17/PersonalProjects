using CookingApp.Models;
using CookingApp.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class RecipeByUserController : ControllerBase
    {
        public class RecipeByUserFrontEnd
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public string Kcal { get; set; }
            public string PreparationTime { get; set; }
            public string CookingTime { get; set; }
            public string Ingredients { get; set; }
            public string Email { get; set; }
        };
        private readonly IRecipeByUserRepository recipeByUserRepository;
        public RecipeByUserController(IRecipeByUserRepository recipeByUserRepository)
        {
            this.recipeByUserRepository = recipeByUserRepository;
        }

        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<RecipeByUser>>> Search(string name)
        {
            try
            {
                var result = await recipeByUserRepository.Search(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");

            }
        }

     
        [HttpGet("GetRecipes")]
        public async Task<ActionResult> GetRecipes()
        {
            try
            {
                return Ok(await recipeByUserRepository.GetRecipes());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("GetRecipesByUser/{email}")]
        public async Task<ActionResult> GetRecipes(string email)
        {
            try
            {
                return Ok(await recipeByUserRepository.GetRecipesByUser(email));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }


        [HttpGet("GetRecipe/{id:int}")]
        public async Task<ActionResult<RecipeByUser>> GetRecipe(int id)
        {
            try
            {
                var result = Ok(await recipeByUserRepository.GetRecipe(id));
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost("AddRecipe")]
        public async Task<ActionResult<RecipeByUser>> CreateRecipe([FromBody] RecipeByUserFrontEnd recipe)
        {
            RecipeByUser recipeByUser=new RecipeByUser();
            recipeByUser.Name = recipe.Name;
            recipeByUser.Description = recipe.Description;
            recipeByUser.Image = recipe.Image;
            recipeByUser.Kcal = Convert.ToDouble(recipe.Kcal);
            recipeByUser.PreparationTime = recipe.PreparationTime;
            recipeByUser.CookingTime = recipe.CookingTime;
            recipeByUser.Ingredients = recipe.Ingredients;
            try
            {
                var createdRecipe = await recipeByUserRepository.AddRecipe(recipeByUser, recipe.Email);
                return CreatedAtAction(nameof(GetRecipe),
                    new { id = createdRecipe.RecipeByUserId }, createdRecipe);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new recipe record");
            }

        }

        [HttpPut("Update")]
        public async Task<ActionResult<RecipeByUser>> UpdateRecipeByUser([FromBody] RecipeByUserFrontEnd recipe)
        {
            try
            {
                //if (id != recipe.Id)
                //    return BadRequest("Recipe id missmatch");
                var recipeToUpdate = await recipeByUserRepository.GetRecipe(recipe.Id);
                if (recipeToUpdate == null)
                {
                    return NotFound($"Recipe with Id={recipe.Id} not found");
                }
                RecipeByUser recipeByUser = new RecipeByUser();
                recipeByUser.RecipeByUserId = recipe.Id;
                recipeByUser.Name = recipe.Name;
                recipeByUser.Description = recipe.Description;
                recipeByUser.Image = recipe.Image;
                recipeByUser.Kcal = Convert.ToDouble(recipe.Kcal);
                recipeByUser.PreparationTime = recipe.PreparationTime;
                recipeByUser.CookingTime = recipe.CookingTime;
                recipeByUser.Ingredients = recipe.Ingredients;
                return await recipeByUserRepository.UpdateRecipe(recipeByUser);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating recipe record");
            }

        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            try
            {
                var recipeToDelete = await recipeByUserRepository.GetRecipe(id);
                if (recipeToDelete == null)
                {
                    return NotFound($"Recipe with Id={id} not found");
                }
                await recipeByUserRepository.DeleteRecipe(id);
                return Ok($"Recipe with Id={id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting recipe record");
            }
        }
    }
}
    