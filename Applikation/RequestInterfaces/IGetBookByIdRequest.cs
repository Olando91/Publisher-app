namespace Applikation.RequestInterfaces;

public interface IGetBookByIdRequest
{
    Guid BookId { get; set; }
}
