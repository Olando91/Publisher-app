namespace Applikation.DTOs;

public record CoverDTO
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public Guid BookId { get; set; }
    public List<ArtistDTO> Artists { get; set;}
}
