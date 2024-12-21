using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorService(IUnitOfWork unitOfWork, IMapper mapper) 
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<AuthorDTO> AddAuthorAsync(AuthorDTO authorDTO)
    {
        var author = _mapper.Map<Author>(authorDTO);
        var result = await _unitOfWork.Authors.AddAsync(author);
         await _unitOfWork.Complete();
        return authorDTO;
    }

    public Task<AuthorDTO> DeleteAuthor(AuthorDTO authorDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthorDTO> GetAuthorByIdAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);
        return _mapper.Map<AuthorDTO>(author);
    }

    public async Task<List<AuthorDTO>> GetAuthorsAsync()
    {
        var authors = await _unitOfWork.Authors.GetAllAsync();
        return _mapper.Map<List<AuthorDTO>>(authors);
    }

    public Task<AuthorDTO> UpdateAuthor(AuthorDTO authorDTO)
    {
        throw new NotImplementedException();
    }
}
