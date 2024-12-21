

namespace Domain.Models;

public class CategoryDTO
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public ICollection<BookCategoryDTO>? BookCategories { get; set; }

}
