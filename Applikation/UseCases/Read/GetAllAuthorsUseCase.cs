using Applikation.ApiResponse;
using Applikation.DTOs.Author;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetAllAuthorsUseCase : IUseCase<IGetAllAuthorsRequest, IResponse<List<AuthorDTO>>>
{
    private readonly IAuthorRepository _authorRepo;
    public GetAllAuthorsUseCase(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }
    public IResponse<List<AuthorDTO>> Execute(IGetAllAuthorsRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<List<AuthorDTO>>> ExecuteAsync(IGetAllAuthorsRequest request)
    {
        try
        {
            var authors = await _authorRepo.GetAllAuthorsAsync();

            var authorDTOs = authors.Select(a => a.TilDTO()).ToList();

            return new ResponseBuilder().CreateSuccessResponse(authorDTOs, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<List<AuthorDTO>>(HttpStatusCode.InternalServerError, e);
        }
    }
}
