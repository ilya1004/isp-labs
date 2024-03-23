using BookManager.App.AuthorUseCases.Handlers;
using BookManager.App.AuthorUseCases.Queries;
using BookManager.App.BookUseCases.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped<AddAuthorHadler>();
        services.AddScoped<GetAllAuthorsHandler>();

        services.AddScoped<AddBookHandler>();
        services.AddScoped<GetBooksByAuthorHandler>();

        return services;
    }
}
