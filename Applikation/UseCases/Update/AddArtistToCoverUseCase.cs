using Applikation.ApiResponse;
using Applikation.DTOs.Cover;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate.ValueObjects;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Update;

public class AddArtistToCoverUseCase : IUseCase<IAddArtistToCoverRequest, IResponse<CoverDTO>>
{
    private readonly IArtistRepository _artistRepo;
    private readonly ICoverRepository _coverRepo;

    public AddArtistToCoverUseCase(IArtistRepository artistRepo, ICoverRepository coverRepo)
    {
        _artistRepo = artistRepo;
        _coverRepo = coverRepo;
    }

    public IResponse<CoverDTO> Execute(IAddArtistToCoverRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<CoverDTO>> ExecuteAsync(IAddArtistToCoverRequest request)
    {
        try
        {
            var artist = await _artistRepo.GetArtistByIdAsync(ArtistId.Create(request.ArtistId));
            var cover = await _coverRepo.GetCoverByIdAsync(CoverId.Create(request.CoverId));

            cover.AddArtist(artist);

            _coverRepo.SaveChangesAsync();

            var coverDTO = cover.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(coverDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<CoverDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
