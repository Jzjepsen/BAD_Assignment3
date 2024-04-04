using Bakery.Models;

namespace Bakery.DTOs;

public class DeliveriesDto
{
    public int TrackId { get; set; }
    public string Street { get; set; } = string.Empty;
    public int Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}