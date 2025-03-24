using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Publisher_GUI.Data.Forms;
using Publisher_GUI.Data.Requests;
using Publisher_GUI.Models;
using Publisher_GUI.Models.Cover;

namespace Publisher_GUI.Data.Repositories;

public class CoverRepository : BaseRepository
{
    public CoverRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authStateProvider) : base(httpClient, configuration, sessionStorage, authStateProvider)
    {
    }

    public async Task<APIResponse<List<Cover>>> GetAllCovers()
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.GetAsync(HentBaseUrl() + "cover/get-all-covers");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<APIResponse<List<Cover>>>() ?? new();
        }
        else
        {
            var err = await response.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }
    } 

    public async Task DeleteCover(Guid coverId)
    {
        await SetAuthorizeHeader();
        var queryParams = $"?coverid={coverId}";
        var response = await _httpClient.DeleteAsync(HentBaseUrl() + "cover/delete-cover-by-id" + queryParams);
    }

    public async Task EditCover(EditCoverRequest editedCover)
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.PutAsJsonAsync(HentBaseUrl() + "cover/edit-cover", editedCover);
    }
    public async Task CreateCover(AddCoverRequest cover)
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.PostAsJsonAsync(HentBaseUrl() + "cover/add-cover", cover);
    }

    public async Task AddArtistToCover(AddArtistToCoverRequest request)
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.PutAsJsonAsync(HentBaseUrl() + "cover/add-artist-to-cover", request);
    }

    public async Task RemoveArtistFromCover(RemoveArtistFromCoverRequest request)
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.PutAsJsonAsync(HentBaseUrl() + "cover/remove-artist-from-cover", request);
    }
}
