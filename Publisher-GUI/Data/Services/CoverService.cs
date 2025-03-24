using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Data.Requests;
using Publisher_GUI.Models;
using Publisher_GUI.Models.Cover;

namespace Publisher_GUI.Data.Services;

public class CoverService
{
    private readonly CoverRepository _coverRepo;

    public CoverService(CoverRepository coverRepo)
    {
        _coverRepo = coverRepo;
    }

    public async Task<List<Cover>> GetAllCovers()
    {
        try
        {
            var covers = await _coverRepo.GetAllCovers();

            return covers.Data;
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task DeleteCover(Guid coverId)
    {
        try
        {
            await _coverRepo.DeleteCover(coverId);
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task EditCover(EditCoverRequest editedCover)
    {
        try
        {
            await _coverRepo.EditCover(editedCover);
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task CreateCover(AddCoverRequest cover)
    {
        try
        {
            await _coverRepo.CreateCover(cover);
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task AddArtistToCover(AddArtistToCoverRequest request)
    {
        try
        {
            await _coverRepo.AddArtistToCover(request);
        }
        catch(Error e)
        {
            throw e;
        }
    }

    public async Task RemoveArtistFromCover(RemoveArtistFromCoverRequest request)
    {
        try
        {
            await _coverRepo.RemoveArtistFromCover(request);
        }
        catch (Error e)
        {
            throw e;
        }
    }
}
