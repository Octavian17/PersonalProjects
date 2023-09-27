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
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepository;
        public RecipeController(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<Recipe>>> Search(string name)
        {
            try
            {
                var result = await recipeRepository.Search(name);
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

     
        [HttpGet]
        public async Task<ActionResult> GetRecipes()
        {
            try
            {
                return Ok(await recipeRepository.GetRecipes());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("GetRecipesByAuthor/{firstName}/{lastName}")]
        public async Task<ActionResult> GetRecipes(string firstName, string lastName)
        {
            try
            {
                return Ok(await recipeRepository.GetRecipesByAuthor(firstName, lastName));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            try
            {
                var result = Ok(await recipeRepository.GetRecipe(id));
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

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            try
            {
                var createdRecipe = await recipeRepository.AddRecipe(recipe);
                return CreatedAtAction(nameof(GetRecipe),
                    new { id = createdRecipe.RecipeId }, createdRecipe);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new recipe record");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int id, Recipe recipe)
        {
            try
            {
                if (id != recipe.RecipeId)
                    return BadRequest("Recipe id missmatch");
                var recipeToUpdate = await recipeRepository.GetRecipe(id);
                if (recipeToUpdate == null)
                {
                    return NotFound($"Recipe with Id={id} not found");
                }
                return await recipeRepository.UpdateRecipe(recipe);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating recipe record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteRecipe(int id)
        {
            try
            {
                var recipeToDelete = await recipeRepository.GetRecipe(id);
                if (recipeToDelete == null)
                {
                    return NotFound($"Recipe with Id={id} not found");
                }
                await recipeRepository.DeleteRecipe(id);
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
    