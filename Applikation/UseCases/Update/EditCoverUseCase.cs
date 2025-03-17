using Applikation.ApiResponse;
using Applikation.DTOs.Cover;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Update;

public class EditCoverUseCase : IUseCase<IEditCoverRequest, IResponse<CoverDTO>>
{
    private readonly ICoverRepository _coverRepo;

    public EditCoverUseCase(ICoverRepository coverRepo)
    {
        _coverRepo = coverRepo;
    }

    public IResponse<CoverDTO> Execute(IEditCoverRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<CoverDTO>> ExecuteAsync(IEditCoverRequest request)
    {
        try
        {
            var coverToEdit = await _coverRepo.GetCoverByIdAsync(CoverId.Create(request.CoverId));

            coverToEdit.Edit(DesignIdea.Create(request.DesignIdea), DigitalOnly.Create(request.DigitalOnly));

            await _coverRepo.SaveChangesAsync();

            var editedCoverDTO = coverToEdit.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(editedCoverDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<CoverDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
