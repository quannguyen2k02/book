using System.Linq.Expressions;
using Domain.Entities;
using Domain.Models;

namespace Application.IService;

public interface IBookService
{
    public Task<BookDTO> AddBookAsync(BookDTO bookDTO);
    public Task<List<BookDTO>> GetBooksAsync();
    public Task<BookDTO> UpdateBook(BookDTO bookDTO);
    public Task<BookDTO> GetBookByIdAsync(int id);
    public Task<BookDTO> DeleteBook(int id);
    public Task<(List<BookDTO> books, int totalCount, int totalPages)> GetBooksPaged(int pageNumber, int pageSize, string? text);
    public Task<List<BookDTO>> GetBooksByCategory(int categoryId);
}
