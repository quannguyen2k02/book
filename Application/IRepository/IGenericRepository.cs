using System.Linq.Expressions;

namespace Application.IRepository;


public interface IGenericRepository<T> where T : class
{
    public Task<T> GetByIdAsync(int id);
    public Task<List<T>> GetAllAsync();
    public Task<List<T>> Find(Expression<Func<T, bool>> predicate);
    public Task<T>AddAsync(T entity);
    public Task<T> Update(T entity);
}
