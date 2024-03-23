using BookManager.App.BookUseCases.Queries;

namespace BookManager.App.BookUseCases.Handlers;

public class AddBookHandler : IRequestHandler<AddBookQuery, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public AddBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(AddBookQuery request, CancellationToken cancellationToken)
    {
        var book = new Book(0, request.Name, request.WritedYear, request.Genre.Trim(),
            request.Rating, request.ImagePath, request.AuthorId);

        await _unitOfWork.BooksRepository.AddAsync(book, cancellationToken);

        await _unitOfWork.SaveAllAsync();

        return book.Id;
    }
}
