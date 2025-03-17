using Domain.AuthorAggregate;
using Domain.AuthorAggregate.ValueObjects;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;
using Domain.Primitives;

namespace Domain.BookAggregate;

public sealed class Book : AggregateRoot<BookId>
{
    public Title Title { get; private set; }
    public PublishDate PublishDate { get; private set; }
    public BasePrice BasePrice { get; private set; }
    public AuthorId AuthorId { get; private set; }
    public Author Author { get; private set; }
    public Cover? Cover { get; private set; }
    private Book()
    {
    }

    private Book(BookId id, Title title, PublishDate publishDate, BasePrice basePrice, AuthorId authorId, Author author, Cover? cover) : base(id)
    {
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        AuthorId = authorId;
        Author = author;
        Cover = cover;
    }

    public static Book Create(BookId id, Title title, PublishDate publishDate, BasePrice basePrice, AuthorId authorId, Author author, Cover? cover)
    {
        return new(id, title, publishDate, basePrice, authorId, author, cover);
    }

    public static Book CreateNew(Title title, PublishDate publishDate, BasePrice basePrice, AuthorId authorId, Author author, Cover? cover)
    {
        return new(BookId.CreateUnique(), title, publishDate, basePrice, authorId, author, cover);
    }

    public void Edit(Title title, PublishDate publishDate, BasePrice basePrice)
    {
        if (Title != title)
            Title = title;

        if (PublishDate != publishDate)
            PublishDate = publishDate;

        if (BasePrice != basePrice)
            BasePrice = basePrice;
    }
}
