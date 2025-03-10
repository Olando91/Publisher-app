using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class GetArtistByIdRequest : IGetArtistByIdRequest
{
    public Guid ArtistId { get; set; }

    public GetArtistByIdRequest()
    {        
    }

    public GetArtistByIdRequest(Guid artistId)
    {
        ArtistId = artistId;
    }

    public bool RequestIsValid()
    {
        if (ArtistId == Guid.Empty)
            return false;

        return true;
    }
}
