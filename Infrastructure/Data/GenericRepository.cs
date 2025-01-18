using System.Linq.Expressions;
using Application.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<(List<T> Items, int TotalCount, int totalPages)> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? predicate = null)
    {
        var query = _context.Set<T>().AsQueryable();
        if(predicate != null)
        {
            query = query.Where(predicate);
        }
        int totalCount = await query.CountAsync();
        List<T> items = await query
            .Skip((pageNumber-1)*pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
        return (items, totalCount, totalPages);
    }

    public async Task<T> Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }
}
