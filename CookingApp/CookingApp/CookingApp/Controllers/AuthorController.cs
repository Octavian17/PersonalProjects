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
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository aRepo = null;

        public AuthorController(IAuthorRepository aRepo)
        {
            this.aRepo = aRepo;
        }
        [HttpGet("GetAuthors")]
        public async Task<ActionResult> GetAuthors()
        {
            try
            {
                return Ok(await aRepo.GetAuthors());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddAuthor(Author author)
        {
            try
            {
                var createdAuthor = await aRepo.AddAuthor(author);
                return StatusCode(StatusCodes.Status200OK,
                    "Added successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new recipe record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            try
            {
                var authorToDelete = await aRepo.GetAuthor(id);
                if (authorToDelete == null)
                {
                    return NotFound($"Author with Id={id} not found");
                }
                await aRepo.DeleteAuthor(id);
                return Ok($"Author with Id={id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting author record");
            }
        }

    }
}
