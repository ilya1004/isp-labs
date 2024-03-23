using BookManager.Persistence.Data;
using BookManager.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions options) 
    {
        services.AddPersistence()
                .AddSingleton<BookManagerDbContext>(new BookManagerDbContext((DbContextOptions<BookManagerDbContext>)options));
        return services;
    }
}
