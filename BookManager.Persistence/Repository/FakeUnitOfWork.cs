
using BookManager.Persistence.Data;

namespace BookManager.Persistence.Repository;

public class FakeUnitOfWork : IUnitOfWork
{
    private readonly BookManagerDbContext _dbContext;
    private readonly Lazy<IRepository<Book>> _booksRepository;
    private readonly Lazy<IRepository<Author>> _authorsRepository;

    public FakeUnitOfWork()
    {
        //_dbContext = dbContext;
        _booksRepository = new Lazy<IRepository<Book>>(() => new FakeBooksRepository());
        _authorsRepository = new Lazy<IRepository<Author>>(() => new FakeAuthorsRepository());
    }

    public IRepository<Book> BooksRepository => _booksRepository.Value;
    public IRepository<Author> AuthorsRepository => _authorsRepository.Value;
    public async Task CreateDatabaseAsync() => await _dbContext.Database.EnsureCreatedAsync();
    public async Task DeleteDatabaseAsync() => await _dbContext.Database.EnsureDeletedAsync();
    public async Task SaveAllAsync() => await _dbContext.SaveChangesAsync();
}
