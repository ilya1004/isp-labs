using BookManager.App.BookUseCases.Queries;

namespace BookManager.App.BookUseCases.Handlers;

public class GetBooksByAuthorHandler : IRequestHandler<GetBooksByAuthorQuery, List<Book>>
{
    private IUnitOfWork _unitOfWork;
    public GetBooksByAuthorHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Book>> Handle(GetBooksByAuthorQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BooksRepository.ListAsync((book) => book.AuthorId == request.AuthorId, cancellationToken);
    }
}
