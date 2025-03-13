using System.Net;

namespace Publisher_GUI.Models;

public class APIResponse<T>
{
    public T? Data { get; set; }
    public Error? Error { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public APIResponse()
    {        
    }

    public APIResponse(HttpStatusCode statusCode, T data)
    {
        Data = data;
        Error = default;
        StatusCode = statusCode;
    }

    public APIResponse(HttpStatusCode statusCode, Error error)
    {
        Data = default;
        Error = error;
        StatusCode = statusCode;
    }
}
