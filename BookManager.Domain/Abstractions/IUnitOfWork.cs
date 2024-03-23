using BookManager.Domain.Entities;

namespace BookManager.Domain.Abstractions;

public interface IUnitOfWork
{
    IRepository<Book> BooksRepository { get; }
    IRepository<Author> AuthorsRepository { get; }
    public Task SaveAllAsync();
    public Task DeleteDatabaseAsync();
    public Task CreateDatabaseAsync();
}
