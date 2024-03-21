using Bakery.Context;
using Bakery.DTOs;
using Bakery.Models;
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

    [HttpPost("new-order")]
    public IActionResult CreateNewOrder([FromBody] OrdersDto ordersDto)
    {
        // Step 2: Validate the received DTO
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Step 3: Create a new Orders entity and map the properties from the DTO
        var newOrder = new Orders
        {
            DeliveryPlace = ordersDto.DeliveryPlace,
            Date = ordersDto.Date,
        };

        // Step 4: Add the new entity to the Orders DbSet
        _context.Orders.Add(newOrder);

        // Step 5: Save changes to the database
        _context.SaveChanges();

        // Step 6: Return a response
        // Using nameof(GetOrderDetails) to redirect to the details of the newly created order
        // Assuming GetOrderDetails is a suitable endpoint to show the order's details
        return CreatedAtAction(nameof(GetOrderDetails), new { id = newOrder.OrderId }, newOrder);
    }
}