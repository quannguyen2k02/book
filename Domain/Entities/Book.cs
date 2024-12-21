using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;
[Table("Book")]
public class Book:CommonAbstract
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal PriceSale { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public DateTime PublishedDate { get; set; }
    [JsonIgnore]

    public ICollection<BookCategory>? BookCategories { get; set; }
    [JsonIgnore]

    public ICollection<OrderDetail>? OrderDetails { get; set; }
    public bool IsDeleted { get; set; }
}

