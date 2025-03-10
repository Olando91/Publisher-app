using Domain.Exceptions;
using Domain.Exceptions.Error;
using System.Net;

namespace Applikation.ApiResponse;

public class ResponseBuilder
{
    public Response<T> CreateErrorResponse<T>(HttpStatusCode statusCode, Exception ex)
    {
        IError error = new Error(ErrorCode.TemplateDomainException, ex.Message);
        var response = new Response<T>(statusCode, ex, error.ErrorCode);

        return response;
    }

    public Response<T> CreateDomainErrorResponse<T>(HttpStatusCode statusCode, DomainException ex)
    {
        return new Response<T>(statusCode, ex);
    }

    public Response<T> CreateSuccessResponse<T>(T data, HttpStatusCode statusCode)
    {
        return new Response<T>(statusCode, data);
    }
}
