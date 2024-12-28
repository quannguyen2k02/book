using System.Text.Json.Serialization;
using Domain.Entities;

namespace Domain.Models;

public class UserDTO
{
    public string? Address { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }
    [JsonIgnore]

    public ICollection<OrderDTO> Orders { get; set; }
}
