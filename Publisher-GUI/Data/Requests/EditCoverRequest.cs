namespace Publisher_GUI.Data.Requests;

public class EditCoverRequest
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
}
