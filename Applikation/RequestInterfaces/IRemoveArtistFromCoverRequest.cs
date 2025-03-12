namespace Applikation.RequestInterfaces;

public interface IRemoveArtistFromCoverRequest
{
    Guid CoverId { get; set; }
    Guid ArtistId { get; set; }
}
