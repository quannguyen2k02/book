using Application.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryDTO category)
    {
        if (ModelState.IsValid) 
        {
            var result = await _categoryService.AddCategoryAsync(category);
            return Ok(result);
        }
        return BadRequest(ModelState);
    }
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }
}
