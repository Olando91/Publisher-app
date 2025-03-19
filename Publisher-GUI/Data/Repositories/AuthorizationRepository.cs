
using Publisher_GUI.Models;
using Publisher_GUI.Models.Authorization;
using System.Net;

namespace Publisher_GUI.Data.Repositories;

public class AuthorizationRepository : BaseRepository
{
    public AuthorizationRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
    {
    }

    public async Task<LoginResponseModel> CheckCredentials(LoginModel loginModel)
    {
        //var queryParams = $"?username={loginModel.Username}&password={loginModel.Password}";

        //var response = await _httpClient.GetAsync(HentBaseUrl() + "authentication/login" + queryParams);

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
