using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;

namespace Applikation.Porte.Udgående;

public interface IAuthorRepository
{
    Task AddAuthorAsync(Author author);
    Task SaveChangesAsync();

    Task DeleteAuthorByIdAsync(AuthorId id);
    Task<Author> GetAuthorByIdAsync(AuthorId id);
    Task<List<Author>> GetAllAuthorsAsync();

}
