using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class DeleteBookRequest : IDeleteBookRequest
{
    public Guid BookId { get; set; }

    public DeleteBookRequest()
    {
    }

    public DeleteBookRequest(Guid bookId)
    {
        BookId = bookId;
    }

    public bool RequestIsValid()
    {
        if (BookId == Guid.Empty)
            return false;

        return true;
    }
}
