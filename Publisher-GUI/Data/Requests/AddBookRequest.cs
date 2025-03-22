using static MudBlazor.Colors;

namespace Publisher_GUI.Data.Requests;

public class AddBookRequest
{
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public Guid AuthorId { get; set; }

    public AddBookRequest()
    {        
        PublishDate = DateOnly.FromDateTime(DateTime.Today);
    }

    public AddBookRequest(string title, DateOnly publishDate, int basePrice, Guid authorId)
    {
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        AuthorId = authorId;
    }
}
