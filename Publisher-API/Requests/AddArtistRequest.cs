using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class AddArtistRequest : IAddArtistRequest
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

    public bool RequestIsValid()
    {
        if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            return false;

        return true;
    }
}
