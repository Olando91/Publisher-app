using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class EditAuthorRequest : IEditAuthorRequest
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

    public bool RequestIsValid()
    {
        if (AuthorId == Guid.Empty || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            return false;

        return true;
    }
}
