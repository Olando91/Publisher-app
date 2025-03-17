using Applikation.DTOs.Book;
using Domain.BookAggregate;

namespace Applikation.ExtensionMetoder;

public static class BookExtensionMethods
{
    public static BookDTO TilDTO(this Book book)
    {
        return new BookDTO
        {
            Id = book.Id.Value,
            Title = book.Title.Value,
            PublishDate = book.PublishDate.Value,
            BasePrice = book.BasePrice.Value,
            Author = book.Author.TilBookAuthorDTO(),
            Cover = book.Cover?.TilBookCoverDTO() ?? null

        };
    }
    public static AuthorBookDTO TilAuthorBookDTO(this Book book)
    {
        return new AuthorBookDTO
        {
            Id = book.Id.Value,
            Title = book.Title.Value,
            PublishDate = book.PublishDate.Value,
            BasePrice = book.BasePrice.Value,
            Cover = book.Cover?.TilBookCoverDTO() ?? null
        };
    }

    public static CoverBookDTO TilCoverBookDTO(this Book book)
    {
        return new CoverBookDTO
        {
            Id = book.Id.Value,
            Title = book.Title.Value,
            PublishDate = book.PublishDate.Value,
            BasePrice = book.BasePrice.Value,
            Author = book.Author.TilBookAuthorDTO()
        };
    }
}
