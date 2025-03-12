using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class RemoveArtistFromCoverRequest : IRemoveArtistFromCoverRequest
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

    public bool RequestIsValid()
    {
        if (CoverId == Guid.Empty || ArtistId == Guid.Empty)
            return false;

        return true;
    }
}
