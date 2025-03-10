using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Delete;

public class DeleteArtistByIdUseCase : IUseCase<IDeleteArtistByIdRequest, IResponse<string>>
{
    private readonly IArtistRepository _artistRepo;

    public DeleteArtistByIdUseCase(IArtistRepository artistRepo)
    {
        _artistRepo = artistRepo;
    }

    public IResponse<string> Execute(IDeleteArtistByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IDeleteArtistByIdRequest request)
    {
        try
        {
            await _artistRepo.DeleteArtistByIdAsync(ArtistId.Create(request.ArtistId));

            await _artistRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
