using Bakery.Context;
using Bakery.DTOs;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;

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
    
    // actions
    [HttpGet]
    public IActionResult GetAllIngredients()
    {
        var ingredient = _context.Ingredients.ToList();
        return Ok(ingredient);
    }
    
    //minimum query #1 from assignment 2
    [HttpGet("all-quantities")]
    public IActionResult GetAllIngredientsWithQuantities()
    {
        var ingredients = _context.Ingredients
            .Select(i => new IngredientQuantityDto
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
        return Ok(ingredient);
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
            return NotFound($"Ingredient with anme {ingredientName} was not found");
        }

        return Ok(ingredient);
    }
    
    // C. update ingredient in stock
    [HttpPut("{id}")]
    public IActionResult UpdateIngredient(int id, [FromBody] IngredientDto ingredientUpdate)
    {
        var ingredient = _context.Ingredients.Find(id);
        if (ingredient == null)
        {
            return NotFound();
        }

        ingredient.Name = ingredientUpdate.Name ?? ingredient.Name;
        ingredient.Quantity = ingredientUpdate.Quantity;

        _context.SaveChanges();
        return NoContent();
    }

      
    // C. add new ingredient and quantity to the stock
    [HttpPost]
    public IActionResult AddIngredient([FromBody] IngredientDto ingredientDto)
    {
        if (ingredientDto == null || string.IsNullOrWhiteSpace(ingredientDto.Name))
        {
            return BadRequest("Invalid ingredient data.");
        }

        var ingredient = new Ingredients
        {
            Name = ingredientDto.Name,
            Quantity = ingredientDto.Quantity
        };

        _context.Ingredients.Add(ingredient);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetIngredientStock), new { ingredientName = ingredient.Name }, ingredient);
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