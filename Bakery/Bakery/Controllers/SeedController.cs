using Microsoft.AspNetCore.Mvc;
using Bakery.Data;
using Bakery.Context;

namespace Bakery.Controllers;

[ApiController]
[Route("[controller]")]
public class SeedController : ControllerBase
{
    private readonly ILogger<SeedController> _logger;
    private readonly MyDbContext _context;

    public SeedController(ILogger<SeedController> logger, MyDbContext context)
    {
        _logger = logger;    
        _context = context;
    }
    
    
    [HttpPut(Name = "Seed")]
    public void Put()
    {
        var seedData = new SeedData();
        seedData.Seed(_context);
    }
}