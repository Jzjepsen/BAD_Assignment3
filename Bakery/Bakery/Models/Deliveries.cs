namespace Bakery.Models;

public class Deliveries
{
    public int TrackId { get; set; }
    public Address Location { get; set; }

    public int OrderId { get; set; }
    public Orders Order { get; set; }

    public int SupermarketId { get; set; }
    public Supermarkets Supermarket { get; set; }
}