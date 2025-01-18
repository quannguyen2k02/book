using Application.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Book>> GetBooksByCategory(int categoryId)
    {
        var books = await _context.BookCategories.Where(x=>x.CategoryId == categoryId)
                    .Select(bc=>bc.Book).ToListAsync();
        return books;
    }


}
