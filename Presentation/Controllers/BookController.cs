using Application.IService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    /// <summary>
    /// Add new book
    /// </summary>
    /// <param name="bookDTO"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddBook(BookDTO bookDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var result = await _bookService.AddBookAsync(bookDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        return BadRequest(ModelState);
    }
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var result = await _bookService.GetBooksAsync();
        return Ok(result);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            var result = await _bookService.DeleteBook(id);
            return Ok(result);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBook(BookDTO bookDTO)
    {
        try
        {
            var result = await _bookService.UpdateBook(bookDTO);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }
}
