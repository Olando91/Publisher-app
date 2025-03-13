using Publisher_GUI.Data.Repositories;
using Publisher_GUI.Models;
using Publisher_GUI.Models.Author;

namespace Publisher_GUI.Data.Services;

public class AuthorService
{
    private readonly AuthorRepository _authorRepo;

    public AuthorService(AuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }

    public async Task<Author> GetAuthorById(Guid authorId)
    {
        try
        {
            var author = await _authorRepo.GetAuthorById(authorId);

            return author.Data;
        }
        catch (Error e)
        {
            throw e;
        }
    }

    public async Task<List<Author>> GetAllAuthors()
    {
        try
        {
            var authors = await _authorRepo.GetAllAuthors();

            return authors.Data;
        }
        catch (Error e)
        {
            throw e;
        }
    }
}
