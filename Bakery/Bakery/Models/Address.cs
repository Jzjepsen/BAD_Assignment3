using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Address
{
    [Key] public int AddressId { get; set; }
    public int Zip { get; set; }
    public string Street { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public List<Orders> Orders { get; set; }
    public List<Deliveries> Deliveries { get; set; }

    public Supermarkets Supermarket { get; set; }
}