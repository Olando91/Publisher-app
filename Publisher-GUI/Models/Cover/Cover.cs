using Publisher_GUI.Models.Artist;
using Publisher_GUI.Models.Book;

namespace Publisher_GUI.Models.Cover;

public class Cover
{
    public Guid Id { get; set; }
    public string DesignIdea { get; set; }
    public bool DigitalOnly { get; set; }
    public CoverBook Book { get; set; }
    public List<CoverArtist> Artists { get; set; }

    public Cover()
    {        
    }

    public Cover(Guid id, string designIdea, bool digitalOnly, CoverBook book, List<CoverArtist> artists)
    {
        Id = id;
        DesignIdea = designIdea;
        DigitalOnly = digitalOnly;
        Book = book;
        Artists = artists;
    }
}
