using BookManager.App.AuthorUseCases.Queries;

namespace BookManager.App.AuthorUseCases.Handlers;

public class AddAuthorHadler : IRequestHandler<AddAuthorQuery, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public AddAuthorHadler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(AddAuthorQuery request, CancellationToken cancellationToken)
    {
        var author = new Author(0, request.Name, request.Surname, request.DateOfBirth, request.DateOfDeath);

        await Console.Out.WriteLineAsync(request.Name);
        await Console.Out.WriteLineAsync(request.Surname);
        await Console.Out.WriteLineAsync(request.DateOfBirth.ToString());
        await Console.Out.WriteLineAsync(request.DateOfDeath.ToString());

        await _unitOfWork.AuthorsRepository.AddAsync(author, cancellationToken);

        await _unitOfWork.SaveAllAsync();

        return author.Id;
    }
}
