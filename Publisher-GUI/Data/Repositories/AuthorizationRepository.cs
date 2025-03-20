
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Publisher_GUI.Models;
using Publisher_GUI.Models.Authorization;
using System.Net;

namespace Publisher_GUI.Data.Repositories;

public class AuthorizationRepository : BaseRepository
{
    public AuthorizationRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authenticationStateProvider) : base(httpClient, configuration, sessionStorage, authenticationStateProvider)
    {
    }

    public async Task<LoginResponseModel> CheckCredentials(LoginModel loginModel)
    {
        await SetAuthorizeHeader();
        var res = await _httpClient.PostAsJsonAsync(HentBaseUrl() + "authentication/login", loginModel);

        if (res.StatusCode == HttpStatusCode.OK)
        {
            return await res.Content.ReadFromJsonAsync<LoginResponseModel>() ?? null;
        }
        else
        {
            var err = await res.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }

    }
}
