namespace Bakery.Models;

public class Supermarkets
{
    public int SupermarketId { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    
    public ICollection<Deliveries> Deliveres { get; set; }
}