using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Infrastructure.ExternalServices.Mapper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper() 
    {
        CreateMap<Book, BookDTO>();
        CreateMap<Author, AuthorDTO>();
        CreateMap<BookCategory, BookCategoryDTO>();
        CreateMap<Category, CategoryDTO>();
        CreateMap<Customer, CustomerDTO>();
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDetail, OrderDetailDTO>();

        //reverse mapper

        CreateMap<BookDTO, Book>();
        CreateMap<AuthorDTO, Author>();
        CreateMap<BookCategoryDTO, BookCategory>();
        CreateMap<CategoryDTO, Category>();
        CreateMap<CustomerDTO, Customer>();
        CreateMap<OrderDTO, Order>();
        CreateMap<OrderDetailDTO, OrderDetail>();
    }
}
