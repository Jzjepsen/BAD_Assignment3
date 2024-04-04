using System.ComponentModel.DataAnnotations;

namespace Bakery.DTOs
{
    public class IngredientNameQuantityDto
    {
        public string Name { get; set; } = string.Empty;
        // Quantity must be a non-negative number
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative number.")]
        public int Quantity { get; set; }
    }
}
