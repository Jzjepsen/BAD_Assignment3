using System.ComponentModel.DataAnnotations;

namespace Bakery.DTOs;

public class OrdersDto
{
    [Required(ErrorMessage = "Delivery place is required.")]
    [StringLength(100, ErrorMessage = "Delivery place cannot exceed 100 characters.")]
    public string DeliveryPlace { get; set; }
    
    //RegularExpression validate correct format is DDMMYYYY HHMM
    [Required(ErrorMessage = "Date is required.")]
    [RegularExpression(@"^\d{2}\d{2}\d{4} \d{2}\d{2}$", ErrorMessage = "Invalid date format. The correct format is DDMMYYYY HHMM.")]
    public string Date { get; set; }

}