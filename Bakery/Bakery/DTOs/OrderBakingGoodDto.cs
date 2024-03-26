using Bakery.Models;

namespace Bakery.DTOs;

public class OrderBakingGoodDto
{
    public string Name { get; set; }
    public int Quantity { get; set; } // Assuming this represents quantity per order
}