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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository cRepo = null;

        public CategoryController(ICategoryRepository cRepo)
        {
            this.cRepo = cRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetRecipes()
        {
            try
            {
                return Ok(await cRepo.GetCategories());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Ingredients>> PostCategory(Category category)
        {
            try
            {
                var createdCat = await cRepo.PostCategory(category);
                return CreatedAtAction(nameof(createdCat),
                    new { id = createdCat.CategoryId }, createdCat);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new category record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                var authorToDelete = await cRepo.GetCategory(id);
                if (authorToDelete == null)
                {
                    return NotFound($"Category with Id={id} not found");
                }
                await cRepo.DeleteCategory(id);
                return Ok($"Category with Id={id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting category record");
            }
        }

    }
}
