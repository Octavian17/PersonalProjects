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
    public class RecipeIngredientController : Controller
    {
        private readonly IRecipeIngredientRepository riRepo = null;

        public RecipeIngredientController(IRecipeIngredientRepository riRepo)
        {
            this.riRepo = riRepo;
        }

        [HttpGet("/ingredientsByRecipes/{id}")]
        public async Task<ActionResult> GetIngredientsByRecipe(int id)
        {
            try
            {
                return Ok(await riRepo.GetIngredientsByRecipe(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Recipe>> GetRecipeIngredient(int id)
        {
            try
            {
                var result = Ok(await riRepo.GetRecipeIngredient(id));
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
        public async Task<ActionResult<Recipe>> CreateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            try
            {
                var createdRecipeIngredient = await riRepo.AddRecipeIngredient(recipeIngredient);
                return CreatedAtAction(nameof(GetRecipeIngredient),
                    new { id = createdRecipeIngredient.RecipeIngredientId }, createdRecipeIngredient);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new recipe record");
            }

        }

        [HttpGet("/recipesByIngredients/{ingredients}")]
        public async Task<ActionResult<IEnumerable<RecipeIngredient>>> GetRecipesByIngredients([FromRoute] string[] ingredients)
        {
            try
            {
                var result = await riRepo.GetRecipesByIngredients(ingredients);
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

        [HttpGet("/recipesIngredients")]
        public async Task<ActionResult> GetRecipeIngredients()
        {
            try
            {
                return Ok(await riRepo.GetRecipeIngredients());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteRecipeIngredient(int id)
        {
            try
            {
                var recipeToDelete = await riRepo.GetRecipeIngredient(id);
                if (recipeToDelete == null)
                {
                    return NotFound($"Recipe with Id={id} not found");
                }
                await riRepo.DeleteRecipeIngredient(id);
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

