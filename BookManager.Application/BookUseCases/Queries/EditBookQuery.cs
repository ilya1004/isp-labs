using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.App.BookUseCases.Queries;

public record EditBookQuery : IRequest
{
    public EditBookQuery(int id, string name, int writedYear, string genre, double rating, string imagePath, int authorId)
    {
        Id = id;
        Name = name;
        WritedYear = writedYear;
        Genre = genre;
        Rating = rating;
        ImagePath = imagePath;
        AuthorId = authorId;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int WritedYear { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public string ImagePath { get; set; }
    public int AuthorId { get; set; }
}
