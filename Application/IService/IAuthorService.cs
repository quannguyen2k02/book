using Domain.Models;

namespace Application.IService;

public interface IAuthorService
{
    public Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDTO);
    public Task<List<AuthorDTO>> GetAuthorsAsync();
    public Task<AuthorDTO> GetAuthorByIdAsync(int id);
    public Task<AuthorDTO> UpdateAuthor(AuthorDTO authorDTO);
    public Task<AuthorDTO> DeleteAuthor(AuthorDTO authorDTO);
}
