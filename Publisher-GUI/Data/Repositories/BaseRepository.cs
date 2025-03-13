namespace Publisher_GUI.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly HttpClient _httpClient;
    protected readonly IConfiguration _configuration;

    protected BaseRepository(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    protected string HentBaseUrl()
    {
        return _configuration.GetValue<string>("base-url");
    }
}
