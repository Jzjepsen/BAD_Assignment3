using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Allergen
{
    [Key]
    public int AllergenId { get; set; }
    public string Name { get; set; }
    public ICollection<IngredientAllergen> IngredientAllergens { get; set; }
}