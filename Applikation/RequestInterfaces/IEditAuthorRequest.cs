namespace Applikation.RequestInterfaces;

public interface IEditAuthorRequest
{
    Guid AuthorId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
}
