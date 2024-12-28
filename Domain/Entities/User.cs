using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;
[Table("User")]
public class User:IdentityUser
{
    public string? Address { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    [JsonIgnore]

    public ICollection<Order> Orders { get; set; }
    public bool IsDeleted { get; set; }

}
