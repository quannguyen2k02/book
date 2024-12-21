using Domain.Entities;

namespace Domain.Models;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public ICollection<OrderDTO> Orders { get; set; }
}
