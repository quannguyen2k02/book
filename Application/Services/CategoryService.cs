using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDTO)
    {
        var category = _mapper.Map<Category>(categoryDTO);
        var categories = await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.Complete();
        return _mapper.Map<CategoryDTO>(categories);
    }

    public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return _mapper.Map<List<CategoryDTO>>(categories);
    }
}
