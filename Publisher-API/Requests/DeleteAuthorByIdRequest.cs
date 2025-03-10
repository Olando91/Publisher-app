using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class DeleteAuthorByIdRequest : IDeleteAuthorByIdRequest
{
    public Guid AuthorId { get; set; }

    public DeleteAuthorByIdRequest()
    {
    }

    public DeleteAuthorByIdRequest(Guid authorId)
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
