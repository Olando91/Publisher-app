using Applikation.ApiResponse;
using Applikation.DTOs.Cover;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetCoverByIdUseCase : IUseCase<IGetCoverByIdRequest, IResponse<CoverDTO>>
{
    private readonly ICoverRepository _coverRepo;

    public GetCoverByIdUseCase(ICoverRepository coverRepo)
    {
        _coverRepo = coverRepo;
    }

    public IResponse<CoverDTO> Execute(IGetCoverByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<CoverDTO>> ExecuteAsync(IGetCoverByIdRequest request)
    {
        try
        {
            var cover = await _coverRepo.GetCoverByIdAsync(CoverId.Create(request.CoverId));

            var coverDto = cover.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(coverDto, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<CoverDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
