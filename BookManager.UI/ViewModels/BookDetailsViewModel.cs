using BookManager.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookManager.UI.ViewModels;

[QueryProperty(nameof(Book), "book")]
public partial class BookDetailsViewModel : ObservableObject
{
    private IMediator _mediator;
    public BookDetailsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    Book book;

    [RelayCommand]
    async Task EditBookItem() => await GoToEditBookPage();


    [RelayCommand]
    async Task AddBookItem() => await GoToAddBookPage();

    private async Task GoToAddBookPage()
    {
        await Shell.Current.GoToAsync(nameof(AddBook));
    }

    private async Task GoToEditBookPage()
    {
        var parameters = new Dictionary<string, object>()
        {
            {"book", Book }
        };
        await Shell.Current.GoToAsync(nameof(EditBook), parameters);
    }
}
