using Bakery.Models;

namespace Bakery.DTOs;

public class OrderBakingGoodDto
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}