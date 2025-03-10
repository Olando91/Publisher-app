namespace Domain.Exceptions.Error;

public class Error : IError
{
    public Error(ErrorCode errorCode, string message)
    {
        ErrorCode = errorCode;
        ErrorMessage = message;
    }
    public ErrorCode ErrorCode { get; }

    public string ErrorMessage { get; }
}
