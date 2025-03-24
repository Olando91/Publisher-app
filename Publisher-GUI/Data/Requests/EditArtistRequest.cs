namespace Publisher_GUI.Data.Requests;

public class EditArtistRequest
{
    public Guid ArtistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public EditArtistRequest()
    {        
    }

    public EditArtistRequest(Guid artistId, string firstName, string lastName)
    {
        ArtistId = artistId;
        FirstName = firstName;
        LastName = lastName;
    }
}
