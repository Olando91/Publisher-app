namespace Domain.UserAggregate;

public class User
{
    public User()
    {
        UserRoles = new List<UserRole>();
    }
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; }
}
