using System.ComponentModel.DataAnnotations;

namespace Bakery.Controllers;

public class IngredientDto
{
    public string Name { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
    public int Quantity { get; set; }
}