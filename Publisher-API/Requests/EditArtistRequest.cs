using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class EditArtistRequest : IEditArtistRequest
{
    public Guid ArtistId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public EditArtistRequest()
    {       
    }

    public EditArtistRequest(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public bool RequestIsValid()
    {
        if (ArtistId == Guid.Empty || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            return false;

        return true;
    }
}
