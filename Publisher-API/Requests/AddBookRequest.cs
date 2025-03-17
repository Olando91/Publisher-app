using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class AddBookRequest : IAddBookRequest
{
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public Guid AuthorId { get; set; }

    public AddBookRequest()
    {
    }

    public AddBookRequest(string title, DateOnly publishDate, int basePrice, Guid authorId)
    {
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        AuthorId = authorId;
    }

    public bool RequestIsValid()
    {
        if (string.IsNullOrEmpty(Title) || AuthorId == Guid.Empty)
            return false;

        return true;
    }
}
