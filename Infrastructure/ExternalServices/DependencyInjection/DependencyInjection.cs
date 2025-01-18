using Application.IRepository;
using Infrastructure.Data;
using Infrastructure.ExternalServices.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ExternalServices.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Đăng ký DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Book")));

        // Đăng ký các Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
        //Đăng kí extension
        services.AddAutoMapper(typeof(ApplicationMapper));

        return services;
    }
}
