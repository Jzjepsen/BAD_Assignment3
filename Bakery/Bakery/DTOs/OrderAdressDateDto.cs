using Bakery.Models;

namespace Bakery.DTOs;

public class OrderAddressDateDto
{
    public Address DeliveryPlace { get; set; }
    public string Date { get; set; }
}