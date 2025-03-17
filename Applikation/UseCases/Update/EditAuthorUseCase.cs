using Applikation.ApiResponse;
using Applikation.DTOs.Author;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using Domain.Common;
using System.Net;

namespace Applikation.UseCases.Update;

public class EditAuthorUseCase : IUseCase<IEditAuthorRequest, IResponse<AuthorDTO>>
{
    private readonly IAuthorRepository _authorRepo;

    public EditAuthorUseCase(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }

    public IResponse<AuthorDTO> Execute(IEditAuthorRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<AuthorDTO>> ExecuteAsync(IEditAuthorRequest request)
    {
        try
        {
            var author = await _authorRepo.GetAuthorByIdAsync(AuthorId.Create(request.AuthorId));

            author.Edit(FirstName.Create(request.FirstName), LastName.Create(request.LastName));

            await _authorRepo.SaveChangesAsync();

            var authorDTO = author.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(authorDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<AuthorDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
