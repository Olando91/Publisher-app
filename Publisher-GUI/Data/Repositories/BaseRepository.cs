using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Publisher_GUI.Data.Services.Authentication;
using Publisher_GUI.Models.Authorization;
using System.Net.Http.Headers;

namespace Publisher_GUI.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly HttpClient _httpClient;
    protected readonly IConfiguration _configuration;
    protected readonly ProtectedSessionStorage _sessionStorage;
    protected readonly AuthenticationStateProvider _authStateProvider;

    protected BaseRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authStateProvider)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _sessionStorage = sessionStorage;
        _authStateProvider = authStateProvider;
    }

    protected string HentBaseUrl()
    {
        return _configuration.GetValue<string>("base-url");
    }

    protected async Task SetAuthorizeHeader()
    {
        var sessionState = (await _sessionStorage.GetAsync<LoginResponseModel>("sessionState")).Value;
        if (sessionState != null && !string.IsNullOrEmpty(sessionState.Token))
        {
            if (sessionState.TokenExpired < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            {
                await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
            }
            else if (sessionState.TokenExpired < DateTimeOffset.UtcNow.AddMinutes(10).ToUnixTimeSeconds())
            {
                var res = await _httpClient.GetFromJsonAsync<LoginResponseModel>(HentBaseUrl() + $"authentication/login-by-refresh-token?refreshToken={sessionState.RefreshToken}");
                if (res != null)
                {
                    await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsAuthenticated(res);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Token);
                }
                else
                {
                    await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
                }
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionState.Token);
            }
        }
    }
}
