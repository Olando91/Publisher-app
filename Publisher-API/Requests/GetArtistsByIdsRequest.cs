using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class GetArtistsByIdsRequest : IGetArtistsByIdsRequest
{
    public List<Guid> ArtistIds { get; set; }

    public GetArtistsByIdsRequest()
    {        
    }

    public GetArtistsByIdsRequest(List<Guid> artistIds)
    {
        ArtistIds = artistIds;
    }

    public bool RequestIsValid()
    {
        if (ArtistIds == null || !ArtistIds.Any())
            return false;

        return true;
    }
}
