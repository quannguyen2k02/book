using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;
[Table("Customer")]
public class Customer:CommonAbstract
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    [JsonIgnore]

    public ICollection<Order> Orders { get; set; }
    public bool IsDeleted { get; set; }

}
