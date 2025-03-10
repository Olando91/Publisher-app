using Domain.Exceptions.Error;
using System.Net;

namespace Applikation.ApiResponse;

public interface IResponse<T>
{
    T? Data { get; set; }
    IError? Error { get; set; }
    HttpStatusCode StatusCode { get; set; }
}
