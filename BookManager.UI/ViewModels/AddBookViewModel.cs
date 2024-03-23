using BookManager.App.AuthorUseCases.Queries;
using BookManager.App.BookUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookManager.UI.ViewModels;

public partial class AddBookViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public AddBookViewModel(IMediator mediator)
    {
        _mediator = mediator;
        Rating = 5;
        WritedYear = 1900;
    }

    public ObservableCollection<Author> Authors { get; set; } = [];

    [ObservableProperty]
    string name;

    [ObservableProperty]
    int writedYear;

    [ObservableProperty]
    string genre;

    [ObservableProperty]
    double rating;

    [ObservableProperty]
    string imagePath;

    [ObservableProperty]
    int authorId;

    [ObservableProperty]
    Author? selectedAuthor;

    [RelayCommand]
    async Task UpdateAuthorsList() => await GetAuthors();

    [RelayCommand]
    async Task Enter() => await AddBook();

    [RelayCommand]
    async Task SelectFile() => await SelectImage();

    private async Task SelectImage()
    {
        var images = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Barcode/QR Code Image",
            FileTypes = FilePickerFileType.Images
        });
        ImagePath = images.FullPath.ToString();
        await Console.Out.WriteLineAsync(ImagePath);
    }

    private async Task AddBook()
    {
        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Genre) || string.IsNullOrEmpty(ImagePath) || SelectedAuthor == null) 
        {
            await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
            return;
        }

        AuthorId = SelectedAuthor.Id;

        await _mediator.Send(new AddBookQuery(Name.Trim(), WritedYear, Genre, Rating, ImagePath, AuthorId));

        await Shell.Current.GoToAsync("//AuthorsList");
    }

    public async Task GetAuthors()
    {
        var authors_req = await _mediator.Send(new GetAllAuthorsQuery());
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Authors.Clear();
            foreach (var author in authors_req)
            {
                Console.WriteLine(author.Name);
                Authors.Add(author);
            }
        });
    }
}
