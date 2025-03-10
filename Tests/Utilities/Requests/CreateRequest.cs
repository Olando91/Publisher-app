using Publisher_API.Requests;

namespace Tests.Utilities.Requests;

public static class CreateRequest
{
    public static AddAuthorRequest AddAuthorRequest() =>
        new AddAuthorRequest(Constants.Constants.FirstName, Constants.Constants.LastName);
}
