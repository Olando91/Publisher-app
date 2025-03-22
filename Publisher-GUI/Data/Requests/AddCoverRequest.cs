namespace Publisher_GUI.Data.Forms;

public class AddCoverRequest
{
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public Guid BookId { get; set; }
    public List<Guid> ArtistIds { get; set; } = new List<Guid>();

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
}
