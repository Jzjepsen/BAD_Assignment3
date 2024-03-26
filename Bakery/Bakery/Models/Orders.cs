using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Bakery.Models;

public class Orders
{
    [Key]
    public int OrderId { get; set; }
    public string Date { get; set; }
    
    public List<OrderBakingGood> OrderBakingGoods { get; set; }
    public List<Deliveries> Deliveries { get; set; }
    
    public int AddressId { get; set; } // FK
    public Address Address { get; set; } // Navigation property
}

