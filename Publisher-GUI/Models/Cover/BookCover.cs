using Publisher_GUI.Models.Artist;

namespace Publisher_GUI.Models.Cover;

public class BookCover
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public List<CoverArtist> Artists { get; set; }
}
