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

    public async Task<T> Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }
}
