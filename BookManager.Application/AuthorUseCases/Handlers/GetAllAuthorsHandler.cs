using BookManager.App.AuthorUseCases.Queries;

namespace BookManager.App.AuthorUseCases.Handlers;

public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
{
    private IUnitOfWork _unitOfWork;
    public GetAllAuthorsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.AuthorsRepository.ListAllAsync(cancellationToken);
    }
}
