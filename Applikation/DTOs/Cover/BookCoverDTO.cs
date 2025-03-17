using Applikation.DTOs.Artist;

namespace Applikation.DTOs.Cover
{
    public record BookCoverDTO
    {
        public Guid Id { get; set; }
        public string DesignIdea { get; set; }
        public bool DigitalOnly { get; set; }
        public List<CoverArtistDTO> Artists { get; set; }
    }
}
