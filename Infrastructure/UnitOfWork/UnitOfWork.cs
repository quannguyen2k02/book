using Application.IRepository;
using Infrastructure.Data;
namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IBookRepository Books { get; private set; }
    public IAuthorRepository Authors { get; private set; }
    public IOrderRepository Orders { get; private set; }
    public ICategoryRepository Categories { get; private set; }

    public IBookCategoryRepository BookCategories {  get; private set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Books = new BookRepository(_context);
        Authors = new AuthorRepository(_context);
        Orders = new OrderRepository(_context);
        Categories = new CategoryRepository(_context);
        BookCategories = new BookCategoryRepository(_context);
    }
    public async Task<int> Complete()
    {
       return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
