using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;
[Table("Category")]
public class Category:CommonAbstract
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    [JsonIgnore]

    public ICollection<BookCategory>? BookCategories { get; set; }
    public bool IsDeleted { get; set; }


}
