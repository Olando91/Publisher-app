using Applikation.Porte.Udgående;
using Domain.BookAggregate;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class BookRepository : IBookRepository
{
    private readonly PublisherDBContext _dbContext;

    public BookRepository(PublisherDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddBookAsync(Book book)
    {
        try
        {
            await _dbContext.Books.AddAsync(book);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteBookByIdAsync(BookId bookId)
    {
        try
        {
            var bookToDelete = await _dbContext.Books.FindAsync(bookId);
            _dbContext.Books.Remove(bookToDelete);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        try
        {
            var books = await _dbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Cover)
                .ThenInclude(c => c.Artists)
                .ToListAsync();

            return books;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Book> GetBookByIdAsync(BookId bookId)
    {
        try
        {
            var book = await _dbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Cover)
                .ThenInclude(c => c.Artists)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            return book;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
