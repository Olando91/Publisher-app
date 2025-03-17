using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class GetBookByIdRequest : IGetBookByIdRequest
{
    public Guid BookId { get; set; }

    public GetBookByIdRequest()
    {
    }

    public GetBookByIdRequest(Guid bookId)
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
