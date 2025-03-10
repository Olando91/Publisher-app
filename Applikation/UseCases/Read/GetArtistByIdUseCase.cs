using Applikation.ApiResponse;
using Applikation.DTOs;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetArtistByIdUseCase : IUseCase<IGetArtistByIdRequest, IResponse<ArtistDTO>>
{
    private readonly IArtistRepository _artistRepo;

    public GetArtistByIdUseCase(IArtistRepository artistRepo)
    {
        _artistRepo = artistRepo;
    }

    public IResponse<ArtistDTO> Execute(IGetArtistByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<ArtistDTO>> ExecuteAsync(IGetArtistByIdRequest request)
    {
        try
        {
            var artist = await _artistRepo.GetArtistByIdAsync(ArtistId.Create(request.ArtistId));

            var artistDTO = artist.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(artistDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<ArtistDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
