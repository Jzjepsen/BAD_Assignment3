using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers;

[ApiController]
[Route("[controller]")]
public class SeedController : ControllerBase
{
    private readonly ILogger<SeedController> _logger;
    
    public SeedController(ILogger<SeedController> logger)
    {
        _logger = logger;
    }
    
    
    [HttpPut(Name = "Seed")]
    public void Put()
    {
        // SeedData()
    }
}