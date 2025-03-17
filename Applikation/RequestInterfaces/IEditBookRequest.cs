namespace Applikation.RequestInterfaces;

public interface IEditBookRequest
{
    Guid BookId { get; set; }
    string Title { get; set; }
    DateOnly PublishDate { get; set; }
    int BasePrice { get; set; }

}
