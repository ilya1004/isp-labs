using BookManager.App.AuthorUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookManager.UI.ViewModels;

public partial class AddAuthorViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public AddAuthorViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string surname;

    [ObservableProperty]
    DateTime dateTimeOfBirth;

    [ObservableProperty]
    DateTime dateTimeOfDeath;

    [RelayCommand]
    async Task Enter() => await AddAuthorToDb();

    private async Task AddAuthorToDb()
    {
        await Shell.Current.DisplayAlert("qweq", "qwef", "errf");

        Name ??= string.Empty;
        Surname ??= string.Empty;
        await _mediator.Send(new AddAuthorQuery(Name.Trim(), Surname.Trim(), DateTimeOfBirth, DateTimeOfDeath));

        await Shell.Current.GoToAsync("//AuthorsList");
    }
}
