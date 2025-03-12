namespace Applikation.RequestInterfaces;

public interface IAddArtistToCoverRequest
{
    Guid CoverId { get; set; }
    Guid ArtistId { get; set; }
}
