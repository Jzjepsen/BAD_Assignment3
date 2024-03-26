using System.ComponentModel.DataAnnotations;
using Bakery.Models;

namespace Bakery.DTOs;

public class OrdersDto
{
    [Required(ErrorMessage = "Delivery place is required.")]
    public List<Address> DeliveryPlace { get; set; }
    
    //RegularExpression validate correct format is DDMMYYYY HHMM
    [Required(ErrorMessage = "Date is required.")]
    [RegularExpression(@"^\d{2}\d{2}\d{4} \d{2}\d{2}$", ErrorMessage = "Invalid date format. The correct format is DDMMYYYY HHMM.")]
    public string Date { get; set; }

}