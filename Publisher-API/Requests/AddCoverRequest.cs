using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class AddCoverRequest : IAddCoverRequest
{
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public Guid BookId { get; set; }
    public List<Guid> ArtistIds { get; set; }

    public AddCoverRequest()
    {        
    }

    public AddCoverRequest(string designIdea, bool digitalOnly, Guid bookId, List<Guid> artistIds)
    {
        DesignIdea = designIdea;
        DigitalOnly = digitalOnly;
        BookId = bookId;
        ArtistIds = artistIds;
    }

    public bool RequestIsValid()
    {
        if (string.IsNullOrEmpty(DesignIdea) || BookId == Guid.Empty || !ArtistIds.Any())
            return false;

        return true;
    }
}
