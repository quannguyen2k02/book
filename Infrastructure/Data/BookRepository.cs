using Application.IRepository;
using Domain.Entities;

namespace Infrastructure.Data;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Book> Delete(Book book)
    {
        book.IsDeleted = true;
        _context.Books.Update(book);
        return book;
    }
}
