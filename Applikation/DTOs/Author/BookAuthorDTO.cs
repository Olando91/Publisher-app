namespace Applikation.DTOs.Author;

public record BookAuthorDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
