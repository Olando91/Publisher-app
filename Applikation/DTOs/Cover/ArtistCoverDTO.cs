using Applikation.DTOs.Book;

namespace Applikation.DTOs.Cover;

public record ArtistCoverDTO
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public CoverBookDTO Book { get; set; }
}
