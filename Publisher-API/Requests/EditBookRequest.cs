using Applikation.RequestInterfaces;

namespace Publisher_API.Requests;

public class EditBookRequest : IEditBookRequest
{
    public Guid BookId { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }

    public EditBookRequest()
    {
    }

    public EditBookRequest(Guid bookId, string title, DateOnly publishDate, int basePrice)
    {
        BookId = bookId;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
    }

    public bool RequestIsValid()
    {
        if (BookId == Guid.Empty || string.IsNullOrEmpty(Title))
            return false;

        return true;
    }
}
