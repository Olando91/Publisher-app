namespace Applikation.RequestInterfaces;

public interface IAddBookRequest
{
    string Title { get; set; }
    DateOnly PublishDate { get; set; }
    int BasePrice { get; set; }
    public Guid AuthorId { get; set; }
}
