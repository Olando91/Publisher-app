using Models.Book;
using Publisher_GUI.Models.Book;

namespace Publisher_GUI.Models.Author;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<AuthorBook> Books { get; set; }

    public Author(Guid id, string firstName, string lastName, List<AuthorBook> books)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Books = books;
    }
    public Author()
    {
    }
    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}
