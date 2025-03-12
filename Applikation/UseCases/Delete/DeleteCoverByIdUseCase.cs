using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Delete;

public class DeleteCoverByIdUseCase : IUseCase<IDeleteCoverByIdRequest, IResponse<string>>
{
    private readonly ICoverRepository _coverRepo;

    public DeleteCoverByIdUseCase(ICoverRepository coverRepo)
    {
        _coverRepo = coverRepo;
    }

    public IResponse<string> Execute(IDeleteCoverByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IDeleteCoverByIdRequest request)
    {
        try
        {
            await _coverRepo.DeleteCoverByIdAsync(CoverId.Create(request.CoverId));

            await _coverRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
