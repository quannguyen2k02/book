using Application.IService;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependenceyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Đăng ký các dịch vụ Application Layer
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        return services;
    }
}
