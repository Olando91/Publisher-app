using Domain.BookAggregate;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate;

namespace Applikation.Porte.Udgående;

public interface IBookRepository
{
    Task AddBookAsync(Book book);
    Task SaveChangesAsync();
    Task DeleteBookByIdAsync(BookId bookId);
    Task<Book> GetBookByIdAsync(BookId bookId);
    Task<List<Book>> GetAllBooksAsync();
}
