using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Deliveries
{
    [Key]
    public int TrackId { get; set; }
    public int DeliveryOrderId { get; set; }
    public Orders Order { get; set; }

    public int SupermarketId { get; set; }
    public Supermarkets Supermarket { get; set; }
    public List<Address> Location {get;set;}
}