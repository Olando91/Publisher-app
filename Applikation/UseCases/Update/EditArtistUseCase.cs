using Applikation.ApiResponse;
using Applikation.DTOs.Artist;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate.ValueObjects;
using Domain.Common;
using System.Net;

namespace Applikation.UseCases.Update;

public class EditArtistUseCase : IUseCase<IEditArtistRequest, IResponse<ArtistDTO>>
{
    private readonly IArtistRepository _artistRepo;

    public EditArtistUseCase(IArtistRepository artistRepo)
    {
        _artistRepo = artistRepo;
    }

    public IResponse<ArtistDTO> Execute(IEditArtistRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<ArtistDTO>> ExecuteAsync(IEditArtistRequest request)
    {
        try
        {
            var artist = await _artistRepo.GetArtistByIdAsync(ArtistId.Create(request.ArtistId));

            artist.Edit(FirstName.Create(request.FirstName), LastName.Create(request.LastName));

            await _artistRepo.SaveChangesAsync();

            var artistDTO = artist.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(artistDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<ArtistDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
