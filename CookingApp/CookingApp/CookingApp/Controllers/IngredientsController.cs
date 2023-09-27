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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsRepository ingredientsRepository;
        public IngredientsController(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }
        

        [HttpGet]
        public async Task<ActionResult> GetIngredients()
        {
            try
            {
                return Ok(await ingredientsRepository.GetIngredients());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ingredients>> GetIngredient(int id)
        {
            try
            {
                var result = Ok(await ingredientsRepository.GetIngredient(id));
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
        public async Task<ActionResult<Ingredients>> SaveIngredient(Ingredients ingredients)
        {
            try
            {
                var createdIngredients = await ingredientsRepository.SaveIngredient(ingredients);
                return CreatedAtAction(nameof(SaveIngredient),
                    new { id = createdIngredients.IngredientsId }, createdIngredients);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new ingredient record");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteIngredient(int id)
        {
            try
            {
                var ingToDelete = await ingredientsRepository.GetIngredient(id);
                if (ingToDelete == null)
                {
                    return NotFound($"Ingredient with Id={id} not found");
                }
                await ingredientsRepository.DeleteIngredient(id);
                return Ok($"Ingredient with Id={id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting ingredient record");
            }
        }
    }
}
