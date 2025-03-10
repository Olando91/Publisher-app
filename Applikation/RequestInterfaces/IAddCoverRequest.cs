namespace Applikation.RequestInterfaces;

public interface IAddCoverRequest 
{
    string DesignIdea { get; set; }
    bool DigitalOnly { get; set; }
    Guid BookId { get; set; }
    List<Guid> ArtistIds { get; set; }
}
