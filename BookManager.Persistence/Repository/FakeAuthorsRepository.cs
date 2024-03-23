using System.Linq.Expressions;

namespace BookManager.Persistence.Repository;

public class FakeAuthorsRepository : IRepository<Author>
{
    private List<Author> _authors;
    public FakeAuthorsRepository()
    {
        _authors = [
            new Author(1, "Name1", "Surname1", new DateTime(1954, 1, 8), new DateTime(2012, 2, 4)),
            new Author(2, "Name2", "Surname2", new DateTime(1935, 3, 6), new DateTime(1987, 3, 2)),
            new Author(3, "Name3", "Surname3", new DateTime(1889, 6, 12), new DateTime(1945, 1, 6)),
        ];


    }

    public Task AddAsync(Author entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Author entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Author?> FirstOrDefaultAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Author?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Author>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => _authors);
    }

    public async Task<List<Author>> ListAsync(Expression<Func<Author, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Author, object>>[]? includesProperties)
    {
        
        return await Task.Run(() => _authors.AsQueryable().Where(filter).ToList());
    }

    public Task UpdateAsync(Author entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
