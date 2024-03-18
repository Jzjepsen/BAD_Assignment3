namespace Bakery.Models;

public class BatchIngredient
{
    public int BatchId { get; set; }
    public int IngredientId { get; set; }
    
    public Batches Batch { get; set; }
    public Ingredients Ingredient { get; set; }
}