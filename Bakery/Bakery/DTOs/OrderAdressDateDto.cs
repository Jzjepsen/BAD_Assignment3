using Bakery.Models;

namespace Bakery.DTOs;

public class OrderAddressDateDto
{
    public Address DeliveryPlace { get; set; } = new Address();
    public string Date { get; set; } = string.Empty;
}