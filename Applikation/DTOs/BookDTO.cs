namespace Applikation.DTOs;

public record BookDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CoverId { get; set; }
}
