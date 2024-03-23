using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace BookManager.Persistence.Repository;

public class FakeBooksRepository : IRepository<Book>
{
    private List<Book> _books;
    public FakeBooksRepository()
    {
        _books =
        [
            new Book(1, "Name1", 1956, "Novel", 9.45, "", 1),
            new Book(2, "Name2", 1989, "Fantasy", 4.67, "", 2),
            new Book(3, "Name3", 2034, "Science fiction", 8.23, "", 3),
        ];
    }

    public Task AddAsync(Book entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Book entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> FirstOrDefaultAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Book, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => _books);
    }

    public async Task<List<Book>> ListAsync(Expression<Func<Book, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Book, object>>[]? includesProperties)
    {
        var filteredBooks = _books.Where(filter.Compile()).ToList();
        return await Task.Run(() => filteredBooks);
    }

    public Task UpdateAsync(Book entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
