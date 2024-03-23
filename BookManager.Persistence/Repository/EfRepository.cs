using BookManager.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookManager.Persistence.Repository;

public class EfRepository<T> : IRepository<T> where T : Entity
{
    private readonly BookManagerDbContext _dbContext;
    private readonly DbSet<T> _entities;
    public EfRepository(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entities.AddAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entities
            .Where(e => e.Id == entity.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
    {
        IQueryable<T>? query = _entities.AsQueryable();

        if (includesProperties != null && includesProperties.Length != 0)
        {
            foreach (Expression<Func<T, object>>? included in includesProperties)
            {
                query = query.Include(included);
            }
        }

        return await query.FirstOrDefaultAsync(el => el.Id == id, cancellationToken);
    }

    public async Task<List<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _entities
            .AsNoTracking()
            .AsQueryable()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
    {
        IQueryable<T>? query = _entities
            .AsNoTracking()
            .AsQueryable();
        if (includesProperties != null && includesProperties.Length != 0)
        {
            foreach (Expression<Func<T, object>>? included in includesProperties)
            {
                query = query.Include(included);
            }
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return await query.ToListAsync();
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        var existingBook = await _dbContext.Books.FindAsync(entity.Id, cancellationToken);
        if (existingBook != null && entity is Book book)
        {
            existingBook.Name = book.Name;
            existingBook.WritedYear = book.WritedYear;
            existingBook.Genre = book.Genre;
            existingBook.Rating = book.Rating;
            existingBook.ImagePath = book.ImagePath;
            existingBook.AuthorId = book.AuthorId;
        }
        await _dbContext.SaveChangesAsync();
    }
}