namespace Publisher_GUI.Models.Author;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }

    public Author(Guid id, string firstName, string lastName, List<Book> books)
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
