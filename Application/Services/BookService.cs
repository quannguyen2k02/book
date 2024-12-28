using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _fileService = fileService;
    }
    public async Task<BookDTO> AddBookAsync([FromForm] BookDTO bookDTO)
    {
        try
        {
            var book = _mapper.Map<Book>(bookDTO);
            var author = await _unitOfWork.Authors.GetByIdAsync(book.AuthorId);//get author
            if (author == null) throw new KeyNotFoundException($"Author with id: {book.AuthorId} not found!");
            var uploadPath = "StaticFiles/Book";
            var fileName = await _fileService.UploadFileAsync(bookDTO.CoverImage, uploadPath);
            book.ImageUrl = Path.Combine("static\\Book", fileName).Replace("\\", "/"); ;
            book.Id = 0;
            var result = await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.Complete();
            return _mapper.Map<BookDTO>(result);
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

    public async Task<BookDTO> DeleteBook(int id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);
        if (book == null) throw new KeyNotFoundException($"Book with id: {id} not found!");
        var result = await _unitOfWork.Books.Delete(book);
        await _unitOfWork.Complete();
        return _mapper.Map<BookDTO>(result);
    }

    public async Task<BookDTO> GetBookByIdAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task<List<BookDTO>> GetBooksAsync()
    {
        var books = await _unitOfWork.Books.GetAllAsync();
        return _mapper.Map<List<BookDTO>>(books);
    }

    public async Task<BookDTO> UpdateBook(BookDTO bookDTO)
    {
        try
        {
            var book = await _unitOfWork.Books.GetByIdAsync(bookDTO.Id);
            if (book == null) throw new KeyNotFoundException($"Book with id: {bookDTO.Id} not found!");
            var checkExistAuthor = await _unitOfWork.Authors.GetByIdAsync(bookDTO.AuthorId);
            if (checkExistAuthor == null) throw new KeyNotFoundException($"Author with id: {bookDTO.AuthorId} not found!");

            if (bookDTO.CoverImage != null)
            {
                var uploadPath = "StaticFiles/Book";
                var fileName = await _fileService.UploadFileAsync(bookDTO.CoverImage, uploadPath);
                bookDTO.ImageUrl = Path.Combine("static\\Book", fileName).Replace("\\", "/"); ;
            }



            _mapper.Map(bookDTO, book);
            await _unitOfWork.Books.Update(book);
            await _unitOfWork.Complete();

            return bookDTO;
        }
        catch(Exception ex) 
        {
            throw;
        }
        
    }
}
