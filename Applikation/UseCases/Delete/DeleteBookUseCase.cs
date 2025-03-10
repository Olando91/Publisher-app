using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Delete;

public class DeleteBookUseCase : IUseCase<IDeleteBookRequest, IResponse<string>>
{
    private readonly IAuthorRepository _authorRepo;

    public DeleteBookUseCase(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }

    public IResponse<string> Execute(IDeleteBookRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IDeleteBookRequest request)
    {
        try
        {
            var author = await _authorRepo.GetAuthorByIdAsync(AuthorId.Create(request.AuthorId));

            author.DeleteBook(BookId.Create(request.BookId));

            await _authorRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
