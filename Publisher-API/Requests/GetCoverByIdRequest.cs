using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class GetCoverByIdRequest : IGetCoverByIdRequest
{
    public Guid CoverId { get; set; }

    public GetCoverByIdRequest()
    {        
    }

    public GetCoverByIdRequest(Guid coverId)
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
