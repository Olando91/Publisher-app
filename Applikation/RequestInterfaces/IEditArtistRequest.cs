namespace Applikation.RequestInterfaces;

public interface IEditArtistRequest
{
    Guid ArtistId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
}
