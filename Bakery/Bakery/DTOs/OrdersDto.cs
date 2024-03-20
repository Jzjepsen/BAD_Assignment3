using System.ComponentModel.DataAnnotations;

namespace Bakery.DTOs;

public class OrdersDto
{
    [Required(ErrorMessage = "Delivery place is required.")]
    [StringLength(100, ErrorMessage = "Delivery place cannot exceed 100 characters.")]
    public string DeliveryPlace { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateOnly Date { get; set; }

}