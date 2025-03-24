namespace Publisher_GUI.Data.Requests;

public class EditAuthorRequest
{
    public Guid AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public EditAuthorRequest()
    {        
    }

    public EditAuthorRequest(Guid authorId, string firstName, string lastName)
    {
        AuthorId = authorId;
        FirstName = firstName;
        LastName = lastName;
    }
}
