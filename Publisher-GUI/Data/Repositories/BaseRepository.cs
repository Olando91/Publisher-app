using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;

namespace Publisher_GUI.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly HttpClient _httpClient;
    protected readonly IConfiguration _configuration;
    protected readonly ProtectedSessionStorage _sessionStorage;

    protected BaseRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _sessionStorage = sessionStorage;
    }

    protected string HentBaseUrl()
    {
        return _configuration.GetValue<string>("base-url");
    }

    protected async Task SetAuthorizeHeader()
    {
        var token = (await _sessionStorage.GetAsync<string>("authToken")).Value;
        if (token != null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
