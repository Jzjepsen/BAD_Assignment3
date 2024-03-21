
namespace Bakery.Models;

public class IngredientAllergen
{
    public int IngredientId { get; set; }
    public Ingredients? Ingredient { get; set; }
    
    public int AllergenId { get; set; }
    public Allergen? Allergen { get; set; }
}