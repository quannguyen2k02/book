using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public  class CreateRequestOrder
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Phone] public string Phone { get; set; }
    public List<OrderItemDTO> OrderItems { get; set; }
}
