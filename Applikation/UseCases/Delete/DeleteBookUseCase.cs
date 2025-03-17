using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using Domain.BookAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Delete;

public class DeleteBookUseCase : IUseCase<IDeleteBookRequest, IResponse<string>>
{
    private readonly IBookRepository _bookRepo;

    public DeleteBookUseCase(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IResponse<string> Execute(IDeleteBookRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IDeleteBookRequest request)
    {
        try
        {
            await _bookRepo.DeleteBookByIdAsync(BookId.Create(request.BookId));
            await _bookRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
