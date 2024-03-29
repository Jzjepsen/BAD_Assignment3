using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Batches
{
    [Key]
    public int BatchId { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly FinishTime { get; set; }
    public TimeOnly ScheduledFinishTime { get; set; }
    
    public List<BakingGoodBatch> BakingGoodBatches { get; set; }
    public List<BatchIngredient> BatchIngredients { get; set; }
}