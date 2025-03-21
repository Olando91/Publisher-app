namespace Publisher_GUI.Data.Forms;

public class EditBookForm
{
    public Guid BookId { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }

    public EditBookForm()
    {        
    }

    public EditBookForm(Guid bookId, string title, DateOnly publishDate, int basePrice)
    {
        BookId = bookId;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
    }
}
