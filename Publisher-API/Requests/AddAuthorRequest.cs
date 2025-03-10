using Applikation.RequestInterfaces;

namespace Publisher_API.Requests
{
    public class AddAuthorRequest : IAddAuthorRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AddAuthorRequest()
        {
        }

        public AddAuthorRequest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool RequestIsValid()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                return false;

            return true;
        }
    }
}
