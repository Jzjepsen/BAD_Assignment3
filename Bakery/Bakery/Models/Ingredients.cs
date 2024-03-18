namespace Bakery.Models;

public class Ingredients
{
    public int IngredientId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    
    public List<BatchIngredient> BatchIngredients { get; set; }
}