using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Requests;
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

    public async Task DeleteArtist(Guid artistId)
    {
        await SetAuthorizeHeader();
        var queryParams = $"?artistId={artistId}";
        var response = await _httpClient.DeleteAsync(HentBaseUrl() + "artist/delete-artist-by-id" + queryParams);
    }

    public async Task EditArtist(EditArtistRequest editedArtist)
    {
        await SetAuthorizeHeader();
        var respone = await _httpClient.PutAsJsonAsync(HentBaseUrl() + "artist/edit-artist", editedArtist);
    }

    public async Task AddArtist(AddArtistRequest newArtist)
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.PostAsJsonAsync(HentBaseUrl() + "artist/add-artist", newArtist);
    }
}
