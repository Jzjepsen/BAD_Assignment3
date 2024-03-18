namespace Bakery.Models;

public class OrderBakingGood
{
    public int OrderId { get; set; }
    public int BakingGoodId { get; set; }
    
    public Orders Order { get; set; }
    public BakingGoods BakingGood { get; set; }
}