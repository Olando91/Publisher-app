using Applikation.DTOs.Author;

namespace Applikation.DTOs.Book;

public record CoverBookDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public BookAuthorDTO Author { get; set; }
}
