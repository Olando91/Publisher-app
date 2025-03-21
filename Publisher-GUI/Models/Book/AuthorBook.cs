using Publisher_GUI.Models.Cover;

namespace Publisher_GUI.Models.Book;

public class AuthorBook
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public BookCover Cover { get; set; }

    public AuthorBook()
    {
    }

    public AuthorBook(Guid id, string title, DateOnly publishDate, int basePrice, BookCover cover)
    {
        Id = id;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        Cover = cover;
    }
}
