using System.Collections.Concurrent;

namespace Application.IRepository;


public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    Task<int> Complete();
}
