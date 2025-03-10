using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class DeleteBookRequest : IDeleteBookRequest
{
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public DeleteBookRequest()
    {
    }

    public DeleteBookRequest(Guid authorId, Guid bookId)
    {
        AuthorId = authorId;
        BookId = bookId;
    }

    public bool RequestIsValid()
    {
        if (AuthorId == Guid.Empty || BookId == Guid.Empty)
            return false;

        return true;
    }
}
