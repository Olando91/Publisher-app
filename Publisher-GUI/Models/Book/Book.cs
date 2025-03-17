using Publisher_GUI.Models.Author;
using Publisher_GUI.Models.Cover;

namespace Models.Book;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public BookAuthor Author{ get; set; }
    public BookCover Cover { get; set; }

    public Book()
    {        
    }

    public Book(Guid id, string title, DateOnly publishDate, int basePrice, BookAuthor author, BookCover cover)
    {
        Id = id;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        Author = author;
        Cover = cover;
    }
}
