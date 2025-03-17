using Applikation.DTOs.Artist;
using Applikation.DTOs.Book;

namespace Applikation.DTOs.Cover;

public record CoverDTO
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public CoverBookDTO Book { get; set; }
    public List<CoverArtistDTO> Artists { get; set;}
}
