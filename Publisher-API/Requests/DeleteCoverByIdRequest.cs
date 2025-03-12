using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class DeleteCoverByIdRequest : IDeleteCoverByIdRequest
{
    public Guid CoverId { get; set; }

    public DeleteCoverByIdRequest()
    {        
    }

    public DeleteCoverByIdRequest(Guid coverId)
    {
        CoverId = coverId;
    }

    public bool RequestIsValid()
    {
        if (CoverId == Guid.Empty)
            return false;

        return true;
    }
}
