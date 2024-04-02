using Bakery.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers;

public class BatchsController : ControllerBase
{
    private readonly MyDbContext _context;

    public BatchsController(MyDbContext context)
    {
        _context = context;
    }

    //query #4 from assignment 2
    [HttpGet("{id}/ingredients")]
    public IActionResult GetIngredientsInBatch(int id)
    {
        var batch = _context.Batches.Find(id);
        if (batch == null)
        {
            return NotFound($"Batch with ID {id} not found.");
        }

        var ingredients = _context.BatchIngredients
            .Where(e => e.BatchId == id)
            .Select(e => new IngredientDto
            {
                Name = e.Ingredient.Name,
                Quantity = e.Ingredient.Quantity,
                Allergens = e.Ingredient.IngredientAllergens
                    .Select(i=> i.Allergen.Name)
                    .ToList()
            })
            .ToList();

        return Ok(ingredients);
    }

    //query #6 from assignment 2
    [HttpGet("averageDelay")]
    public IActionResult GetAverageDelay()
    {
        var batches = _context.Batches.ToList();
        var averageDelay = batches
            .Select(e => (e.FinishTime - e.ScheduledFinishTime).TotalMinutes)
            .Average();
        return Ok(averageDelay);
    }
}