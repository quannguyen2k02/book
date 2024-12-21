using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;
[Table("Author")]
public class Author:CommonAbstract
{
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public string Bio { get; set; }
    [JsonIgnore]

    public ICollection<Book>? Books { get; set; }
    public bool IsDeleted { get; set; }

}
