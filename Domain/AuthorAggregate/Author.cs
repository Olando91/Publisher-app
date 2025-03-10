using Domain.AuthorAggregate.Entities;
using Domain.AuthorAggregate.ValueObjects;
using Domain.Common;
using Domain.Primitives;

namespace Domain.AuthorAggregate;

public sealed class Author : AggregateRoot<AuthorId>
{
    private readonly List<Book> _books = new();
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    private Author()
    {   
    }

    private Author(AuthorId id, FirstName firstName, LastName lastName) : base(id ?? AuthorId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        _books = new();
    }

    public static Author Create(AuthorId id, FirstName firstName, LastName lastName)
    {
        return new(id, firstName, lastName);
    }

    public static Author CreateNew(FirstName firstName, LastName lastName)
    {
        return new(AuthorId.CreateUnique(), firstName, lastName);
    }

    public void Edit(FirstName firstName, LastName lastName)
    {
        if (FirstName != firstName)
            FirstName = firstName;
        if (LastName != lastName)
            LastName = lastName;
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void DeleteBook(BookId bookId)
    {
        var bookToRemove = _books.FirstOrDefault(x => x.Id == bookId);

        _books.Remove(bookToRemove);
    }
}
