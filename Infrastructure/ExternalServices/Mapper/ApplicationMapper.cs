using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Infrastructure.ExternalServices.Mapper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper() 
    {
        CreateMap<Book, BookDTO>().ReverseMap();
        CreateMap<Author, AuthorDTO>().ReverseMap();
        CreateMap<BookCategory, BookCategoryDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
    }
}
