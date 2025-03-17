using Applikation.ApiResponse;
using Applikation.DTOs.Cover;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetAllCoversUseCase : IUseCase<IGetAllCoversRequest, IResponse<List<CoverDTO>>>
{
    private readonly ICoverRepository _coverRepo;

    public GetAllCoversUseCase(ICoverRepository coverRepo)
    {
        _coverRepo = coverRepo;
    }

    public IResponse<List<CoverDTO>> Execute(IGetAllCoversRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<List<CoverDTO>>> ExecuteAsync(IGetAllCoversRequest request)
    {
        try
        {
            var covers = await _coverRepo.GetAllCoversAsync();

            var coverDTOs = covers.Select(c => c.TilDTO()).ToList();

            return new ResponseBuilder().CreateSuccessResponse(coverDTOs, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<List<CoverDTO>>(HttpStatusCode.InternalServerError, e);
        }
    }
}
