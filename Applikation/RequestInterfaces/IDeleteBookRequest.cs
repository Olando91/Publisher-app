namespace Applikation.RequestInterfaces;

public interface IDeleteBookRequest
{
    Guid AuthorId { get; set; }
    Guid BookId { get; set; }
}
