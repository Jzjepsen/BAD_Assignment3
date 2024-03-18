using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class BakingGoods
{
    [Key]
    public int BakingGoodId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    
    public List<OrderBakingGood> OrderBakingGoods { get; set; }
    public List<BakingGoodBatch> BakingGoodBatches { get; set; }
}