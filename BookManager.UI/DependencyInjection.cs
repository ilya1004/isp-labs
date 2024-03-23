using BookManager.UI.Pages;
using BookManager.UI.ViewModels;

namespace BookManager.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddPages(this IServiceCollection services)
    {
        services.AddScoped<AuthorsList>();
        services.AddScoped<BookDetails>();
        services.AddScoped<AddAuthor>();
        services.AddScoped<AddBook>();
        services.AddScoped<EditBook>();
        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddScoped<AuthorsListViewModel>();
        services.AddScoped<BookDetailsViewModel>();
        services.AddScoped<AddAuthorViewModel>();
        services.AddScoped<AddBookViewModel>();
        services.AddScoped<EditBookViewModel>();
        return services;
    }
}
