using Domain.Models;

namespace Application.IService;

public interface IBookService
{
    public Task<BookDTO> AddBookAsync(BookDTO bookDTO);
    public Task<List<BookDTO>> GetBooksAsync();
    public Task<BookDTO> UpdateBook(BookDTO bookDTO);
    public Task<BookDTO> GetBookByIdAsync(int id);
    public Task<BookDTO> DeleteBook(int id);
}
