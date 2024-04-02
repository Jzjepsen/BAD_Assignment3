using System.ComponentModel.DataAnnotations;

namespace Bakery.Controllers;

public class IngredientDto
{
    public string Name { get; set; } = string.Empty;
    // Quantity must be a non-negative number
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
    public int Quantity { get; set; }
    public List<string> Allergens { get; set; }

}