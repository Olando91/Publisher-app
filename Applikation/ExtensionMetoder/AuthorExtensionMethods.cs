using Applikation.DTOs.Author;
using Domain.AuthorAggregate;

namespace Applikation.ExtensionMetoder;

public static class AuthorExtensionMethods
{
    public static AuthorDTO TilDTO(this Author author)
    {
        return new AuthorDTO
        {
            Id = author.Id.Value,
            FirstName = author.FirstName.Value,
            LastName = author.LastName.Value,
            Books = author.Books.Select(x => x.TilAuthorBookDTO()).ToList()
        };
    }

    public static BookAuthorDTO TilBookAuthorDTO(this Author author)
    {
        return new BookAuthorDTO
        {
            Id = author.Id.Value,
            FirstName = author.FirstName.Value,
            LastName = author.LastName.Value,
        };
    }
}
