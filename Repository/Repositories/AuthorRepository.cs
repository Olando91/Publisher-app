using Applikation.Porte.Udgående;
using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly PublisherDBContext _dbContext;

    public AuthorRepository(PublisherDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAuthorAsync(Author author)
    {
        try
        {
            await _dbContext.Authors.AddAsync(author);
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteAuthorByIdAsync(AuthorId id)
    {
        try
        {
            var author = await _dbContext.Authors.FindAsync(id);
            _dbContext.Authors.Remove(author);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        try
        {
            var authors = await _dbContext.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.Cover)
                .ThenInclude(c => c.Artists)
                .ToListAsync();
            return authors;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Author> GetAuthorByIdAsync(AuthorId id)
    {
        try
        {
            var author = await _dbContext.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.Cover)
                .ThenInclude(c => c.Artists)
                .FirstOrDefaultAsync(a => a.Id == id);
            return author;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
