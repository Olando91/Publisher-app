namespace Applikation.DTOs;

public record AuthorDTO()
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<BookDTO> Books { get; set; }
}