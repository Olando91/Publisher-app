namespace Applikation.RequestInterfaces;

public interface IGetArtistsByIdsRequest
{
    List<Guid> ArtistIds { get; set; }
}
