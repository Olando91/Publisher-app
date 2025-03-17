using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using Domain.BookAggregate;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Create;

public class AddBookUseCase : IUseCase<IAddBookRequest, IResponse<string>>
{
    private readonly IAuthorRepository _authorRepo;
    private readonly IBookRepository _bookRepo;
    public AddBookUseCase(IAuthorRepository authorRepo, IBookRepository bookRepo)
    {
        _authorRepo = authorRepo;
        _bookRepo = bookRepo;
    }
    public IResponse<string> Execute(IAddBookRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<string>> ExecuteAsync(IAddBookRequest request)
    {
        try
        {
            var author = await _authorRepo.GetAuthorByIdAsync(AuthorId.Create(request.AuthorId));

            var newBook = Book.CreateNew(Title.Create(request.Title), PublishDate.Create(request.PublishDate), BasePrice.Create(request.BasePrice), author.Id, author, null);

            await _bookRepo.AddBookAsync(newBook);
            await _bookRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
