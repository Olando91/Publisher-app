using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Models;

namespace Publisher_GUI.Data.Services;

public class CoverService
{
    private readonly CoverRepository _coverRepo;

    public CoverService(CoverRepository coverRepo)
    {
        _coverRepo = coverRepo;
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
}
