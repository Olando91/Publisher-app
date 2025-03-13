namespace Publisher_GUI.Models;

public class Error : Exception
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public Error(string? message) : base(message)
    {        
    }

    public Error()
    {        
    }

    protected Error(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}
