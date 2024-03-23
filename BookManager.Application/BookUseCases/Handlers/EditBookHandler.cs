using BookManager.App.BookUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.App.BookUseCases.Handlers;

public class EditBookHandler : IRequestHandler<EditBookQuery>
{
    private readonly IUnitOfWork _unitOfWork;
    public EditBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(EditBookQuery request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Id, request.Name, request.WritedYear, request.Genre, request.Rating, request.ImagePath, request.AuthorId);

        await _unitOfWork.BooksRepository.UpdateAsync(book, cancellationToken);

        //await _unitOfWork.SaveAllAsync();
    }
}
