using Domain.Exceptions;
using Domain.Exceptions.Error;
using System.Net;

namespace Applikation.ApiResponse;

public class Response<T> : IResponse<T>
{
    // Indeholder objekt(er) der requestes
    public T? Data { get; set; }

    // Indeholder ErrorObjekt såfremt StatusCode på API svar ikke er 200
    public IError? Error { get; set; }
    
    // StatusCode på API svar
    public HttpStatusCode StatusCode { get; set; }

    public Response(HttpStatusCode statusCode, T data)
    {
        StatusCode = statusCode;
        Data = data;
        Error = null;
    }

    public Response(HttpStatusCode statusCode, DomainException error)
    {
        StatusCode = statusCode;
        Data = default;
        Error = new Error(error.ErrorCode, error.Message);
    }

    public Response(HttpStatusCode statusCode, Exception error, ErrorCode errorCode)
    {
        StatusCode = statusCode;
        Data = default;
        Error = new Error(errorCode, error.Message);
    }

    public Response(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        Error = null;
    }

}
