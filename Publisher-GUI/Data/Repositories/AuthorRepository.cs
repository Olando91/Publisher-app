using Publisher_GUI.Models;
using Publisher_GUI.Models.Author;
using System.Net;

namespace Publisher_GUI.Data.Repositories;

public class AuthorRepository : BaseRepository
{
    public AuthorRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
    {
    }

    public async Task<APIResponse<Author>> GetAuthorById(Guid authorId)
    {
        var queryParams = $"?authorid={authorId}"; //Er der flereparams sætter man &navnpånæsteparam={value} osv på. 
        var response = await _httpClient.GetAsync(HentBaseUrl() + "author/get-author-by-id" + queryParams);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<APIResponse<Author>>() ?? new();
        }
        else
        {
            var err = await response.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }
    }

    public async Task<APIResponse<List<Author>>> GetAllAuthors()
    {
        var response = await _httpClient.GetAsync(HentBaseUrl()+ "author/get-all-authors");

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<APIResponse<List<Author>>>() ?? new();
        }
        else
        {
            var err = await response.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }

    }
}
