
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class AuthorDTO
{
    public int Id { get; set; }
    [Required]
    public string AuthorName { get; set; }
    public string Bio { get; set; }
    [JsonIgnore]
    public ICollection<BookDTO>? Books { get; set; }
}
