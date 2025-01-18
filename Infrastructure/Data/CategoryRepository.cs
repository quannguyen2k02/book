using Application.IRepository;
using Domain.Entities;

namespace Infrastructure.Data;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
