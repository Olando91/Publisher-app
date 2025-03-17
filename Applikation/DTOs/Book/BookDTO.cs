using Applikation.DTOs.Author;
using Applikation.DTOs.Cover;

namespace Applikation.DTOs.Book;

public record BookDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public BookAuthorDTO Author { get; set; }
    public BookCoverDTO? Cover { get; set; }
}
