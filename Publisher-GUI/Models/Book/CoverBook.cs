using Publisher_GUI.Models.Author;

namespace Publisher_GUI.Models.Book;

public class CoverBook
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public BookAuthor Author { get; set; }

    public CoverBook()
    {
    }

    public CoverBook(Guid id, string title, DateOnly publishDate, int basePrice, BookAuthor author)
    {
        Id = id;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        Author = author;
    }
}
