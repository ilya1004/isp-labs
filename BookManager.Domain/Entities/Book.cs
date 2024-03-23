namespace BookManager.Domain.Entities;

public class Book : Entity
{
    private Book() { }
    public Book(int id, string name, int writedYear, string genre, double rating, string imagePath, int authorId)
    {
        Id = id;
        Name = name;
        WritedYear = writedYear;
        Genre = genre;
        Rating = rating;
        ImagePath = imagePath;
        AuthorId = authorId;
    }

    public string Name { get; set; } = string.Empty;
    public int WritedYear { get; set; }
    public string Genre { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public int? AuthorId { get; set; }
    public Author? Author { get; set; }

    public void AddAuthor(int authorId)
    {
        if (authorId <= 0) return;
        AuthorId = authorId;
    }
}