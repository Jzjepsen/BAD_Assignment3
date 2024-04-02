using System.Globalization;
using Bakery.Context;
using Bakery.DTOs;
using Bakery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [HttpGet("{id}")]
    public IActionResult GetOrderDetails(int id)
    {
        var order = _context.Orders
            .Include(o => o.Address)
            .Where(o => o.OrderId == id)
            .Select(o => new OrdersDto
            {
                Street = o.Address.Street,
                Zip = o.Address.Zip,
                Longitude = o.Address.Longitude,
                Latitude = o.Address.Latitude,
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
    [HttpGet("{id}/bakingGoods")]
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
            .Where(d => d.OrderId == id)
            .Select(d => new DeliveriesDto
            {
                TrackId = d.TrackId,
                Street = d.Address.Street,
                Zip = d.Address.Zip,
                Longitude = d.Address.Longitude,
                Latitude = d.Address.Latitude
            })
            .ToList();

        return Ok(deliveries);
    }

    //query #6 from assignment 2
    [HttpGet("bakingGoods")]
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

    [HttpPost]
    public IActionResult CreateNewOrder([FromBody] OrdersDto ordersDto)
    {
        // Validate the received DTO
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Checking if the date is a valid date
        DateTime validDate;
        if (!DateTime.TryParseExact(ordersDto.Date, "ddMMyyyy HHmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate))
        {
            return BadRequest("Invalid date");
        }

        // Create a new Orders entity and map the properties from the DTO
        var newOrder = new Orders
        {
            Address = new Address { Street = ordersDto.Street, Zip = ordersDto.Zip, Longitude = ordersDto.Longitude, Latitude = ordersDto.Latitude },
            Date = ordersDto.Date,
        };

        // Add the new entity to the Orders DbSet
        _context.Orders.Add(newOrder);

        // Save changes to the database
        _context.SaveChanges();

        // Return a response
        // Using nameof(GetOrderDetails) to redirect to the details of the newly created order
        // Assuming GetOrderDetails is a suitable endpoint to show the order's details
        return CreatedAtAction(nameof(GetOrderDetails), new { id = newOrder.OrderId }, newOrder);
    }
}