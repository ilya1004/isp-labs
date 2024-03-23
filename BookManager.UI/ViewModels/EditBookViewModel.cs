using BookManager.App.AuthorUseCases.Queries;
using BookManager.App.BookUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BookManager.UI.ViewModels;

[QueryProperty(nameof(Book), "book")]
public partial class EditBookViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public EditBookViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public ObservableCollection<Author> Authors { get; set; } = [];

    [ObservableProperty]
    Book book;

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
    int? authorId;

    [ObservableProperty]
    Author? selectedAuthor;

    [RelayCommand]
    async Task UpdateAuthorsList() => await GetAuthors();

    [RelayCommand]
    async Task Enter() => await EditBook();

    [RelayCommand]
    async Task SelectFile() => await SelectImage();

    private async Task EditBook()
    {
        if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Genre) || string.IsNullOrEmpty(ImagePath) || SelectedAuthor == null)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Некоторые поля имеют некорректные значения", "Ок");
            return;
        }

        await _mediator.Send(new EditBookQuery(Book.Id, Name.Trim(), WritedYear, Genre, Rating, ImagePath, SelectedAuthor.Id));

        await Shell.Current.GoToAsync("//AuthorsList");
    }

    private async Task GetAuthors()
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

        Name = Book.Name;
        Genre = Book.Genre;
        WritedYear = Book.WritedYear;
        Rating = Book.Rating;
        ImagePath = Book.ImagePath;
        AuthorId = Book.AuthorId;

        foreach (var item in Authors)
        {
            if (item.Id == AuthorId)
            {
                SelectedAuthor = item;
            }
        }
    }

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
}
