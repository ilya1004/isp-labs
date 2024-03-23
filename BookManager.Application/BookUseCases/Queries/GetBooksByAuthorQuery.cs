namespace BookManager.App.BookUseCases.Queries;

public record GetBooksByAuthorQuery : IRequest<List<Book>>
{
    public GetBooksByAuthorQuery(int authorId)
    {
        AuthorId = authorId;
    }

    public int AuthorId { get; set; }
}
