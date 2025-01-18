using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class OrderItemDTO
{
    [Required]
    public int BookID { get; set; }
    [Required]
    public int Quantity { get; set; }
}
