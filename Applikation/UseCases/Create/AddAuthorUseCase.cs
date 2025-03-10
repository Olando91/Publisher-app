using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate;
using Domain.Common;
using System.Net;

namespace Applikation.UseCases.Create;

public class AddAuthorUseCase : IUseCase<IAddAuthorRequest, IResponse<string>>
{
    private readonly IAuthorRepository _authorRepo;
    public AddAuthorUseCase(IAuthorRepository authorRepository)
    {
        _authorRepo = authorRepository;
    }
    public IResponse<string> Execute(IAddAuthorRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IAddAuthorRequest request)
    {
        try
        {
            var newAuthor = Author.CreateNew(FirstName.Create(request.FirstName), LastName.Create(request.LastName));

            await _authorRepo.AddAuthorAsync(newAuthor);

            await _authorRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
