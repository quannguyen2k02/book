using Domain.Models;

namespace Application.IService;

public interface ICategoryService
{
    public Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO);
    public Task<List<CategoryDTO>> GetAllCategoriesAsync();
    
}
