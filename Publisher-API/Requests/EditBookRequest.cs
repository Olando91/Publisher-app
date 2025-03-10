using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class EditBookRequest : IEditBookRequest
{
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public Guid CoverId { get; set; }

    public EditBookRequest()
    {
    }

    public EditBookRequest(Guid bookid, Guid authorId, string title, DateOnly publishDate, int basePrice, Guid coverId)
    {
        BookId = bookid;
        AuthorId = authorId;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        CoverId = coverId;
    }

    public bool RequestIsValid()
    {
        if (BookId == Guid.Empty || AuthorId == Guid.Empty || string.IsNullOrEmpty(Title) || CoverId == Guid.Empty)
            return false;

        return true;
    }
}
