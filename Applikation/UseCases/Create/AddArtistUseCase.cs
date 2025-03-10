using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate;
using Domain.Common;
using System.Net;

namespace Applikation.UseCases.Create;

public class AddArtistUseCase : IUseCase<IAddArtistRequest, IResponse<string>>
{
    private readonly IArtistRepository _artistRepo;

    public AddArtistUseCase(IArtistRepository artistRepo)
    {
        _artistRepo = artistRepo;
    }

    public IResponse<string> Execute(IAddArtistRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IAddArtistRequest request)
    {
        try
        {
            var newArtist = Artist.CreateNew(FirstName.Create(request.FirstName), LastName.Create(request.LastName));

            await _artistRepo.AddArtistAsync(newArtist);
            await _artistRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
