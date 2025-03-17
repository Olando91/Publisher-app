using Applikation.DTOs.Cover;

namespace Applikation.DTOs.Artist;

public record ArtistDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ArtistCoverDTO> Covers { get; set; }
}
