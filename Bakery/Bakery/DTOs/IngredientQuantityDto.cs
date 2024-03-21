using System.ComponentModel.DataAnnotations;

namespace Bakery.DTOs;

public class IngredientQuantityDto
{
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
    public int Quantity { get; set; }
}