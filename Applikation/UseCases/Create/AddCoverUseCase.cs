using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.ArtistAggregate.ValueObjects;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Create;

public class AddCoverUseCase : IUseCase<IAddCoverRequest, IResponse<string>>
{
    private readonly ICoverRepository _coverRepo;
    private readonly IArtistRepository _artistRepo;
    private readonly IBookRepository _bookRepo;

    public AddCoverUseCase(ICoverRepository coverRepo, IArtistRepository artistRepo, IBookRepository bookRepo)
    {
        _coverRepo = coverRepo;
        _artistRepo = artistRepo;
        _bookRepo = bookRepo;
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
            var book = await _bookRepo.GetBookByIdAsync(BookId.Create(request.BookId));

            var newCover = Cover.CreateNew(
                DesignIdea.Create(request.DesignIdea),
                DigitalOnly.Create(request.DigitalOnly),
                book.Id,
                book,
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
