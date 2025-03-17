using Applikation.ApiResponse;
using Applikation.DTOs.Author;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetAuthorByIdUseCase : IUseCase<IGetAuthorByIdRequest, IResponse<AuthorDTO?>>
{
    private readonly IAuthorRepository _authorRepo;

    public GetAuthorByIdUseCase(IAuthorRepository authorRepository)
    {
        _authorRepo = authorRepository;
    }

    public IResponse<AuthorDTO?> Execute(IGetAuthorByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<AuthorDTO?>> ExecuteAsync(IGetAuthorByIdRequest request)
    {
        try
        {
            var author = await _authorRepo.GetAuthorByIdAsync(AuthorId.Create(request.AuthorId));

            var dto = author.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(dto, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<AuthorDTO?>(HttpStatusCode.InternalServerError, e);
        }

    }
}
