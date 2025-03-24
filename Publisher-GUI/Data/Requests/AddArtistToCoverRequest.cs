namespace Publisher_GUI.Data.Requests;

public class AddArtistToCoverRequest
{
    public Guid CoverId { get; set; }
    public Guid ArtistId { get; set; }

    public AddArtistToCoverRequest()
    {        
    }

    public AddArtistToCoverRequest(Guid coverId, Guid artistId)
    {
        CoverId = coverId;
        ArtistId = artistId;
    }
}
