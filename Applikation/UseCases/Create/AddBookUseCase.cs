using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.Entities;
using Domain.AuthorAggregate.ValueObjects;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Create;

public class AddBookUseCase : IUseCase<IAddBookRequest, IResponse<string>>
{
    private readonly IAuthorRepository _authorRepo;
    public AddBookUseCase(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
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

            var newBook = Book.CreateNew(Title.Create(request.Title), PublishDate.Create(request.PublishDate), BasePrice.Create(request.BasePrice), AuthorId.Create(request.AuthorId), CoverId.Create(request.CoverId));

            author.AddBook(newBook);

            await _authorRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse("Success", HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<string>(HttpStatusCode.InternalServerError, e);
        }
    }
}
