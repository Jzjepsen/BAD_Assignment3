using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Supermarkets
{
    [Key]
    public int SupermarketId { get; set; }
    public string Name { get; set; }
    public List<Deliveries> Deliveres { get; set; }
    public int AddressId { get; set; } 
    public Address Address { get; set; } 
}