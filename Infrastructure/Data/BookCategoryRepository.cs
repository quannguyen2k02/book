using Application.IRepository;
using Domain.Entities;

namespace Infrastructure.Data;

public class BookCategoryRepository : GenericRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }


}
