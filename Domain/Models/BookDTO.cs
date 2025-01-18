
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Domain.Models;

public class BookDTO
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal PriceSale { get; set; }
    public int Stock { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? CoverImage { get; set; }
    public DateTime PublishedDate { get; set; }
    [JsonIgnore]
    public ICollection<BookCategoryDTO>? BookCategories { get; set; }
    [JsonIgnore]
    public ICollection<OrderDetailDTO>? OrderDetails { get; set; }
}
