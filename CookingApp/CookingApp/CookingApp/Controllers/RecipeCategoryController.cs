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
    public class RecipeCategoryController : Controller
    {
        private readonly IRecipeCategoryRepository rcRepo = null;

        public RecipeCategoryController(IRecipeCategoryRepository rcRepo)
        {
            this.rcRepo = rcRepo;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            try
            {
                return Ok(await rcRepo.GetCategory(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetRecipesByCategory(int id)
        {
            try
            {
                return Ok(await rcRepo.GetRecipesByCategory(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("/recipesCategories")]
        public async Task<ActionResult> GetRecipeCategories()
        {
            try
            {
                return Ok(await rcRepo.GetRecipeCategory());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<RecipeCategory>> CreateRecipeCategory(RecipeCategory recipeCategory)
        {
            try
            {
                var createdRecipeCategory = await rcRepo.AddRecipeCategory(recipeCategory);
                return CreatedAtAction(nameof(GetRecipeCategories),
                    new { id = createdRecipeCategory.RecipeCategoryId }, createdRecipeCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new recipe category record");
            }

        }

    }
}
