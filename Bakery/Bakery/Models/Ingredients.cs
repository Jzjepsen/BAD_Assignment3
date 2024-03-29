using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Ingredients
{
    [Key]
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    
    public List<BatchIngredient> BatchIngredients { get; set; }
    public ICollection<IngredientAllergen> IngredientAllergens{ get; set; }
}