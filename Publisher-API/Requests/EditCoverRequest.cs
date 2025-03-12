using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class EditCoverRequest : IEditCoverRequest
{
    public Guid CoverId { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }

    public EditCoverRequest()
    {        
    }

    public EditCoverRequest(Guid coverId, string designIdea, bool digitalOnly)
    {
        CoverId = coverId;
        DesignIdea = designIdea;
        DigitalOnly = digitalOnly;
    }

    public bool RequestIsValid()
    {
        if (CoverId == Guid.Empty || string.IsNullOrEmpty(DesignIdea))
            return false;

        return true;
    }
}
