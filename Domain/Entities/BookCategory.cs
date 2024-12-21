namespace Domain.Entities;
public class BookCategory:CommonAbstract
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int CategoryId { get; set; }
    public bool IsDeleted { get; set; }

}
