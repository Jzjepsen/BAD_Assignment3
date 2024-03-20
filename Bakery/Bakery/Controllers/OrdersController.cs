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

   
}