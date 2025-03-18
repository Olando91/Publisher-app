namespace Publisher_GUI.Models.Artist;

public class CoverArtist
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}
