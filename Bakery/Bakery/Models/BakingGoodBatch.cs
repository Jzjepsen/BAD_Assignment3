namespace Bakery.Models;

public class BakingGoodBatch
{
    public int BakingGoodId { get; set; }
    public int BatchId { get; set; }
    
    public BakingGoods BakingGood { get; set; }
    public Batches Batch { get; set; }
}