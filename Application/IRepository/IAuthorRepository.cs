using Domain.Entities;

namespace Application.IRepository;

public interface IAuthorRepository : IGenericRepository<Author>
{
    public Task<Author> Delete(Author author);
}
