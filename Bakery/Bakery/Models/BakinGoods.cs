namespace Bakery.Models;

public class BakingGoods
{
    public int BakingGoodId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    
    public ICollection<OrderBakingGood> OrderBakingGoods { get; set; }
    public ICollection<BakingGoodBatch> BakingGoodBatches { get; set; }
}