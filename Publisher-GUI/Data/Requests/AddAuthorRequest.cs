namespace Publisher_GUI.Data.Requests;

public class AddAuthorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public AddAuthorRequest()
    {
    }

    public AddAuthorRequest(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
