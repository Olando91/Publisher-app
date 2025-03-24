namespace Publisher_GUI.Data.Requests;

public class RemoveArtistFromCoverRequest
{
    public Guid CoverId { get; set; }
    public Guid ArtistId { get; set; }

    public RemoveArtistFromCoverRequest()
    {        
    }

    public RemoveArtistFromCoverRequest(Guid coverId, Guid artistId)
    {
        CoverId = coverId;
        ArtistId = artistId;
    }
}
