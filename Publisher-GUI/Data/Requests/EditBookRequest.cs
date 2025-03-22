namespace Publisher_GUI.Data.Forms;

public class EditBookRequest
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
}
