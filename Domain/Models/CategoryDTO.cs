

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; }
    [JsonIgnore]
    public ICollection<BookCategoryDTO>? BookCategories { get; set; }

}
