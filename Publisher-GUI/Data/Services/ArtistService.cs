using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Data.Requests;
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

    public async Task DeleteArtist(Guid artistId)
    {
        try
        {
            await _artistRepo.DeleteArtist(artistId);
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task EditArtist(EditArtistRequest editedArtist)
    {
        try
        {
            await _artistRepo.EditArtist(editedArtist);
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task AddArtist(AddArtistRequest newArtist)
    {
        try
        {
            await _artistRepo.AddArtist(newArtist);
        }
        catch (Error e)
        {
            throw e;
        }
    }
}
