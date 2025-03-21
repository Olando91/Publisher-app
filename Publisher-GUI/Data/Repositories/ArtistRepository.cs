using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Publisher_GUI.Data.Forms;
using Publisher_GUI.Models;
using Publisher_GUI.Models.Artist;

namespace Publisher_GUI.Data.Repositories;

public class ArtistRepository : BaseRepository
{
    public ArtistRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authStateProvider) : base(httpClient, configuration, sessionStorage, authStateProvider)
    {
    }

    public async Task<APIResponse<List<Artist>>> GetAllArtists()
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.GetAsync(HentBaseUrl() + "artist/get-all-artists");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<APIResponse<List<Artist>>>() ?? new();
        }
        else
        {
            var err = await response.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }
    }
}
