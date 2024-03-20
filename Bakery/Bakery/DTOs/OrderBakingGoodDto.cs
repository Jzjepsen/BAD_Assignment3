using Bakery.Models;

namespace Bakery.DTOs;

public class OrderBakingGoodDto
{
    //public int OrderId { get; set; }
    //public int BakingGoodId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; } // Assuming this represents quantity per order
    

    //public Orders Order { get; set; }
    //public BakingGoods BakingGood { get; set; }
}