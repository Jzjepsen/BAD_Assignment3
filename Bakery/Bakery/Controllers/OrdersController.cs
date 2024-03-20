using Bakery.Context;
using Bakery.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly MyDbContext _context;
    
    public OrdersController(MyDbContext context)
    {
        _context = context;
    }
    //minimum query #2 from assignment 2
    [HttpGet("{id}/details")]
    public IActionResult GetOrderDetails(int id)
    {
        var order = _context.Orders
            .Where(o => o.OrderId == id)
            .Select(o => new OrderAddressDateDto
            {
                DeliveryPlace = o.DeliveryPlace,
                Date = o.Date
            })
            .FirstOrDefault();
        if (order == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        return Ok(order);
    }
    
    //query #3 from assignment 2
    [HttpGet("{id}/baking-goods")]
    public IActionResult GetBakingGoodsInOrder(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        var bakingGoods = _context.OrderBakingGoods
            .Where(e => e.OrderId == id)
            .Select(e => new OrderBakingGoodDto
            {
                Name = e.BakingGood.Name,
                Quantity = e.BakingGood.Quantity,
            })
            .ToList();

        return Ok(bakingGoods);
    }
    
    //query #5 from assignment 2
    [HttpGet("{id}/deliveries")]
    public IActionResult GetDeliveriesForOrder(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            return NotFound($"Order with ID {id} not found.");
        }

        var deliveries = _context.Deliveries
            .Where(e => e.OrderId == id)
            .Select(e => e.TrackId)
            .ToList();

        return Ok(deliveries);
    }
    
    //query #6 from assignment 2
    [HttpGet("all-bakingGood-quantities")]
      public IActionResult GetAllBakingGoodsQuantities()
        {
            var bakingGoods = _context.OrderBakingGoods
                .GroupBy(e => e.BakingGoodId)
                .Select(e => new OrderBakingGoodDto
                {
                    Name = e.First().BakingGood.Name,
                    Quantity = e.Sum(e => e.BakingGood.Quantity)
                })
                .OrderBy(e => e.Name)
                .ToList();
    
            return Ok(bakingGoods);
        }

   
}