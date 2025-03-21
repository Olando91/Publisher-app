using Publisher_GUI.Models.Cover;

namespace Publisher_GUI.Models.Artist;

public class Artist
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<ArtistCover> Covers { get; set; }

    public Artist()
    {        
    }

    public Artist(Guid id, string firstName, string lastName, List<ArtistCover> covers)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Covers = covers;
    }

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}
