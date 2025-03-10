using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate.ValueObjects;
using Domain.AuthorAggregate.ValueObjects;
using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Create;

public class AddCoverUseCase : IUseCase<IAddCoverRequest, IResponse<string>>
{
    private readonly ICoverRepository _coverRepo;
    private readonly IArtistRepository _artistRepo;

    public AddCoverUseCase(ICoverRepository coverRepo, IArtistRepository artistRepo)
    {
        _coverRepo = coverRepo;
        _artistRepo = artistRepo;
    }

    public IResponse<string> Execute(IAddCoverRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IAddCoverRequest request)
    {
        try
        {

            var artists = await _artistRepo.GetArtistsById(request.ArtistIds.Select(ArtistId.Create).ToList());

            var newCover = Cover.CreateNew(
                DesignIdea.Create(request.DesignIdea),
                DigitalOnly.Create(request.DigitalOnly),
                BookId.Create(request.BookId),
                artists
                );

            await _coverRepo.AddCoverAsync(newCover);
            await _coverRepo.SaveChangesAsync();



            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
