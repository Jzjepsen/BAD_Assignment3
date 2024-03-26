using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Address
{
    [Key] public int AddressId { get; set; }
    public string Zip { get; set; }
    public string Street { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    //foreign key for Deliveries
    public int DeliveryId { get; set; }
    public Deliveries Deliveries { get; set; }

    
}