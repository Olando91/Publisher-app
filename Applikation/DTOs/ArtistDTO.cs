namespace Applikation.DTOs;

public record ArtistDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<CoverDTO> Covers { get; set; }
}
