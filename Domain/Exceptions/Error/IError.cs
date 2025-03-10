namespace Domain.Exceptions.Error;

public interface IError
{
    public ErrorCode ErrorCode { get; }
    public string ErrorMessage { get; }
}
