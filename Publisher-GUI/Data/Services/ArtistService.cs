using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Models;
using Publisher_GUI.Models.Artist;

namespace Publisher_GUI.Data.Services;

public class ArtistService
{
    private readonly ArtistRepository _artistRepo;

    public ArtistService(ArtistRepository artistRepo)
    {
        _artistRepo = artistRepo;
    }

    public async Task<List<Artist>> GetAllArtists()
    {
        try
        {
            var artists = await _artistRepo.GetAllArtists();

            return artists.Data;
        }
        catch (Error e)
        {
            throw e;
        }
    }
}
