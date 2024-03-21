using Bakery.Context;
using Bakery.DTOs;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Controllers;
[ApiController]
[Route("[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly MyDbContext _context;

    public IngredientsController(MyDbContext context)
    {
        _context = context;
    }
  
    
    //minimum query #1 from assignment 2
    [HttpGet("all-quantities")]
    public IActionResult GetAllIngredientsWithQuantities()
    {
        var ingredients = _context.Ingredients
            .Select(i => new IngredientDto
            {
                Name = i.Name,
                Quantity = i.Quantity
            })
            .ToList();

        return Ok(ingredients);
    }

    
    [HttpGet("{id}")]
    public IActionResult GetIngredientById(int id)
    {
        var ingredient = _context.Ingredients.Find(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        var ingredientQuantityDto = new IngredientDto
        {
            Name = ingredient.Name,
            Quantity = ingredient.Quantity
        };

        return Ok(ingredientQuantityDto);
    }

    
    [HttpGet("stock/{ingredientName}")] // Specify a unique route
    public IActionResult GetIngredientStock(string ingredientName)
    {
        var ingredient = _context.Ingredients
            .Where(i => i.Name.ToLower() == ingredientName.ToLower())
            .Select(i => new { i.Name, i.Quantity })
            .FirstOrDefault();
        if (ingredient == null)
        {
            return NotFound($"Ingredient with name {ingredientName} was not found");
        }

        return Ok(ingredient);
    }
    
    // C. update ingredient in stock
    [HttpPut("update-quantity-by-name/{name}")]
    public IActionResult UpdateIngredient(string name, [FromBody] IngredientQuantityDto ingredientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Find the ingredient by name using EF.Functions.Like for case-insensitive comparison
        var ingredient = _context.Ingredients
            .FirstOrDefault(i => EF.Functions.Like(i.Name, name));

        if (ingredient == null)
        {
            // If the ingredient does not exist, consider creating a new one or return NotFound
            // For this scenario, let's return a NotFound response
            return NotFound($"Ingredient with name {name} not found.");
        }

        // If found, update the existing ingredient's quantity by adding the new quantity to it
        ingredient.Quantity += ingredientDto.Quantity;

        _context.SaveChanges();
        return NoContent();
    }



      
    // C. Add new ingredient and quantity to the stock
    [HttpPost]
    public IActionResult AddIngredient([FromBody] IngredientDto ingredientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (ingredientDto == null || string.IsNullOrWhiteSpace(ingredientDto.Name))
        {
            return BadRequest("Invalid ingredient data.");
        }

        // Normalize the ingredient name to lowercase for case-insensitive comparison
        var normalizedName = ingredientDto.Name.ToLower();

        // Check if an existing ingredient with the same name exists (case-insensitive)
        var existingIngredient = _context.Ingredients
            .Any(i => i.Name.ToLower() == normalizedName);

        if (existingIngredient)
        {
            return BadRequest($"An ingredient with the name {ingredientDto.Name} already exists.");
        }

        var newIngredient = new Ingredients
        {
            Name = ingredientDto.Name, 
            Quantity = ingredientDto.Quantity
        };
        _context.Ingredients.Add(newIngredient);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetIngredientStock), new { ingredientName = newIngredient.Name }, newIngredient);
    }

   
    // C. Delete ingredient from stock
    [HttpDelete("{id}")]
    public IActionResult DeleteIngredient(int id)
    {
        var ingredient = _context.Ingredients.Find(id);
        if (ingredient == null)
        {
            return NotFound();
        }

        _context.Ingredients.Remove(ingredient);
        _context.SaveChanges();
        return NoContent();
    }

    

}