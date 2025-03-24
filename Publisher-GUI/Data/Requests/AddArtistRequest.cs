namespace Publisher_GUI.Data.Requests;

public class AddArtistRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public AddArtistRequest()
    {        
    }

    public AddArtistRequest(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
