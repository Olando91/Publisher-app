using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class GetAuthorByIdRequest : IGetAuthorByIdRequest
{
    public Guid AuthorId { get; set; }

    public GetAuthorByIdRequest()
    {
    }

    public GetAuthorByIdRequest(Guid authorId)
    {
        AuthorId = authorId;
    }

    public bool RequestIsValid()
    {
        if (AuthorId == Guid.Empty)
            return false;

        return true;
    }
}
