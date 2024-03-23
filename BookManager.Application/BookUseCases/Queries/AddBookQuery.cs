namespace BookManager.App.BookUseCases.Queries;

public record AddBookQuery : IRequest<int>
{
    public AddBookQuery(string name, int writedYear, string genre, double rating, string imagePath, int authorId)
    {
        Name = name;
        WritedYear = writedYear;
        Genre = genre;
        Rating = rating;
        ImagePath = imagePath;
        AuthorId = authorId;
    }

    public string Name { get; set; }
    public int WritedYear { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public string ImagePath { get; set; }
    public int AuthorId { get; set; }
}
