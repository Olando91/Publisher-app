
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Book;
using Publisher_GUI.Models;
using System.Net;

namespace Publisher_GUI.Data.Repositories;

public class BookRepository : BaseRepository
{
    public BookRepository(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authenticationStateProvider) : base(httpClient, configuration, sessionStorage, authenticationStateProvider)
    {
    }

    public async Task<APIResponse<List<Book>>> GetAllBooksNoAuth()
    {
        var response = await _httpClient.GetAsync(HentBaseUrl() + "public/get-all-books");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<APIResponse<List<Book>>>() ?? new();
        }
        else
        {
            var err = await response.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }
    }

    public async Task<APIResponse<List<Book>>> GetAllBooks()
    {
        await SetAuthorizeHeader();
        var response = await _httpClient.GetAsync(HentBaseUrl() + "book/get-all-books");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<APIResponse<List<Book>>>() ?? new();
        }
        else
        {
            var err = await response.Content.ReadFromJsonAsync<APIResponse<Error>>();
            throw err!.Error!;
        }
    }

    public async Task DeleteBook(Guid bookId)
    {
        await SetAuthorizeHeader();
        var queryParams = $"?bookid={bookId}";
        var response = await _httpClient.DeleteAsync(HentBaseUrl() + "book/delete-book" + queryParams);

        // Får en 415
    }
}
