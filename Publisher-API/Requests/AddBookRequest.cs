using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class AddBookRequest : IAddBookRequest
{
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CoverId { get; set; }

    public AddBookRequest()
    {
    }

    public AddBookRequest(string title, DateOnly publishDate, int basePrice, Guid authorId, Guid coverId)
    {
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        AuthorId = authorId;
        CoverId = coverId;
    }

    public bool RequestIsValid()
    {
        if (string.IsNullOrEmpty(Title) || AuthorId == Guid.Empty || CoverId == Guid.Empty)
            return false;

        return true;
    }
}
