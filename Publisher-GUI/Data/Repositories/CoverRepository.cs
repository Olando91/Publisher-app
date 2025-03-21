using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Publisher_GUI.Data.Forms;

namespace Publisher_GUI.Data.Repositories;

public class CoverRepository : BaseRepository
{
    public CoverRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authStateProvider) : base(httpClient, configuration, sessionStorage, authStateProvider)
    {
    }

    public async Task CreateCover(NewCoverForm cover)
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.PostAsJsonAsync(HentBaseUrl() + "cover/add-cover", cover);
    }
}
