using BookManager.App.AuthorUseCases.Queries;
using BookManager.App.BookUseCases.Queries;
using BookManager.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace BookManager.UI.ViewModels;

public partial class AuthorsListViewModel : ObservableObject
{
    private IMediator _mediator;
    public AuthorsListViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public ObservableCollection<Author> Authors { get; set; } = [];
    public ObservableCollection<Book> Books { get; set; } = [];

    [ObservableProperty]
    Author? selectedAuthor;

    [RelayCommand]
    async Task ShowDetails(Book book) => await GoToDetailsPage(book);

    [RelayCommand]
    async Task UpdateAuthorsList() => await UpdateInfo();

    [RelayCommand]
    async Task UpdateBooksList() => await GetBooks();

    [RelayCommand]
    async Task AddAuthorPage() => await GoToAddAuthorPage();

    public async Task UpdateInfo()
    {   
        var authors_req = await _mediator.Send(new GetAllAuthorsQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Books.Clear();
            Authors.Clear();
            foreach (var author in authors_req)
            {
                Authors.Add(author);
            }
        });
    }

    public async Task GetBooks()
    {
        if (SelectedAuthor == null) return;
        var books_req = await _mediator.Send(new GetBooksByAuthorQuery(SelectedAuthor.Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Books.Clear();
            foreach (var book in books_req)
            {
                Books.Add(book);
            }
        });
    }

    public async Task GoToDetailsPage(Book book)
    {
        var parameters = new Dictionary<string, object>() 
        {
            {"book", book }
        };
        await Shell.Current.GoToAsync(nameof(BookDetails), parameters);
    }

    public async Task GoToAddAuthorPage()
    {
        await Shell.Current.GoToAsync(nameof(AddAuthor));
    }
}
