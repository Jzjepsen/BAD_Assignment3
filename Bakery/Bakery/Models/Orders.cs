using System.Runtime.InteropServices.JavaScript;

namespace Bakery.Models;

public class Orders
{
    public int OrderId { get; set; }
    public Address DeliveryPlace { get; set; }
    public DateOnly Date { get; set; }
    
    public List<OrderBakingGood> OrderBakingGoods { get; set; }
    public List<Deliveries> Deliveries { get; set; }
}