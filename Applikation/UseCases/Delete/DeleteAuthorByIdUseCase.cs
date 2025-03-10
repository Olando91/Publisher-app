using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Delete;

public class DeleteAuthorByIdUseCase : IUseCase<IDeleteAuthorByIdRequest, IResponse<string>>
{
    private readonly IAuthorRepository _authorRepo;

    public DeleteAuthorByIdUseCase(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }
    public IResponse<string> Execute(IDeleteAuthorByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IDeleteAuthorByIdRequest request)
    {
        try
        {
            await _authorRepo.DeleteAuthorByIdAsync(AuthorId.Create(request.AuthorId));

            await _authorRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Author deleted", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
