using Domain.Entities;

namespace Application.IRepository;


public interface IBookRepository : IGenericRepository<Book>
{
    public Task<Book> Delete(Book book);
    public Task<List<Book>> GetBooksByCategory(int categoryId);
}
