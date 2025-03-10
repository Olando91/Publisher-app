namespace Applikation.RequestInterfaces;

public interface IAddBookRequest
{
    string Title { get; set; }
    DateOnly PublishDate { get; set; }
    int BasePrice { get; set; }
    Guid AuthorId { get; set; }
    Guid CoverId { get; set; }
}
