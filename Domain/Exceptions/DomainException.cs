using Domain.Exceptions.Error;

namespace Domain.Exceptions;

public abstract class DomainException : Exception
{
    public ErrorCode ErrorCode { get; set; }
    public DomainException(string? message) : base(message)
    {
    }

    protected DomainException(string message, ErrorCode errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}
