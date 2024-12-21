using Application.IRepository;
using Domain.Entities;

namespace Infrastructure.Data;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Author> Delete(Author author)
    {
        _context.Authors.Update(author);
        return author;
    }
}
