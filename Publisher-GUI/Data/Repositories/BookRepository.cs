
using Models.Book;
using Publisher_GUI.Models;

namespace Publisher_GUI.Data.Repositories;

public class BookRepository : BaseRepository
{
    public BookRepository(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
    {
    }

    public async Task<APIResponse<List<Book>>> GetAllBooks()
    {
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
}
