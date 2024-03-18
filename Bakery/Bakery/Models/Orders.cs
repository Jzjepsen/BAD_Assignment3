using System.Runtime.InteropServices.JavaScript;

namespace Bakery.Models;

public class Orders
{
    public int OrderId { get; set; }
    public Address DeliveryPlace { get; set; }
    public DateOnly Date { get; set; }
    
    public ICollection<OrderBakingGood> OrderBakingGoods { get; set; }
    public ICollection<Deliveries> Deliveries { get; set; }
}