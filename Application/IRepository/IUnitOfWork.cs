namespace Application.IRepository;


public interface IUnitOfWork : IDisposable
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    IOrderRepository Orders { get; }
    ICategoryRepository Categories { get; }
    IBookCategoryRepository BookCategories { get; }
    Task<int> Complete();
}
