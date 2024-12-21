using Application.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService) 
    {
        _authorService = authorService;
    }
    [HttpPost]
    public async Task<IActionResult> AddAuthor(AuthorDTO authorDTO)
    {
        if (ModelState.IsValid)
        {
            var result = await _authorService.AddAuthorAsync(authorDTO);
            return Ok(result);
        }
        return BadRequest(ModelState);
    }
    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _authorService.GetAuthorsAsync();
        return Ok(authors);
    }
}
