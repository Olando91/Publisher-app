using Applikation.ApiResponse;
using Applikation.DTOs;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using System.Net;

namespace Applikation.UseCases.Read
{
    public class GetAllArtistsUseCase : IUseCase<IGetAllArtistsRequest, IResponse<List<ArtistDTO>>>
    {
        private readonly IArtistRepository _artistRepo;

        public GetAllArtistsUseCase(IArtistRepository artistRepo)
        {
            _artistRepo = artistRepo;
        }

        public IResponse<List<ArtistDTO>> Execute(IGetAllArtistsRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<IResponse<List<ArtistDTO>>> ExecuteAsync(IGetAllArtistsRequest request)
        {
            try
            {
                var artists = await _artistRepo.GetAllArtistsAsync();

                var artistDTOs = artists.Select(a => a.TilDTO()).ToList();

                return new ResponseBuilder().CreateSuccessResponse(artistDTOs, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new ResponseBuilder().CreateErrorResponse<List<ArtistDTO>>(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
