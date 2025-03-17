using Applikation.DTOs.Book;

namespace Applikation.DTOs.Author;

public record AuthorDTO()
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<AuthorBookDTO> Books { get; set; }
}