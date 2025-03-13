namespace Publisher_GUI.Models.Author;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishDate { get; set; }
    public int BasePrice { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CoverId { get; set; }

    public Book()
    {        
    }

    public Book(Guid id, string title, DateOnly publishDate, int basePrice, Guid authorId, Guid coverId)
    {
        Id = id;
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        AuthorId = authorId;
        CoverId = coverId;
    }
}
