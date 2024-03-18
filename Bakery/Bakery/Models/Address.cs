using System.ComponentModel.DataAnnotations;

namespace Bakery.Models;

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
}