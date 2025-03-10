using Domain.AuthorAggregate.ValueObjects;
using Domain.CoverAggregate.ValueObjects;
using Domain.Primitives;

namespace Domain.AuthorAggregate.Entities;

public sealed class Book : Entity<BookId>
{
    public Title Title { get; private set; }
    public PublishDate PublishDate { get; private set; }
    public BasePrice BasePrice { get; private set; }
    public AuthorId AuthorId { get; private set; }
    public CoverId CoverId { get; private set; }
    private Book()
    {
    }

    private Book(BookId id, Title title, PublishDate publishDate, BasePrice basePrice, AuthorId authorId, CoverId coverId) : base(id)
    {
        Title = title;
        PublishDate = publishDate;
        BasePrice = basePrice;
        AuthorId = authorId;
        CoverId = coverId;
    }

    public static Book Create(BookId id, Title title, PublishDate publishDate, BasePrice basePrice, AuthorId authorId, CoverId coverId)
    {
        return new(id, title, publishDate, basePrice, authorId, coverId);
    }

    public static Book CreateNew(Title title, PublishDate publishDate, BasePrice basePrice, AuthorId authorId, CoverId coverId)
    {
        return new(BookId.CreateUnique(), title, publishDate, basePrice, authorId, coverId);
    }

    public void Edit(Book book)
    {
        if (Title != book.Title)
            Title = book.Title;

        if (PublishDate != book.PublishDate)
            PublishDate = book.PublishDate;

        if (BasePrice != book.BasePrice)
            BasePrice = book.BasePrice;

        if (CoverId != book.CoverId)
            CoverId = book.CoverId;
    }
}
