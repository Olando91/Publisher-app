namespace Publisher_GUI.Models.Author;

public class BookAuthor
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public BookAuthor()
    {
    }

    public BookAuthor(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}
