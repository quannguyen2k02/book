using System;
using System.Linq.Expressions;

namespace Application.IRepository;


public interface IGenericRepository<T> where T : class
{
    public Task<T> GetByIdAsync(int id);
    public Task<List<T>> GetAllAsync();
    public Task<List<T>> Find(Expression<Func<T, bool>> predicate);
    public Task<T>AddAsync(T entity);
    public Task<T> Update(T entity);
    public Task<(List<T> Items, int TotalCount, int totalPages)> GetPagedAsync(int pageNumber, int pageSize,Expression<Func<T, bool>>? predicate = null);
}
