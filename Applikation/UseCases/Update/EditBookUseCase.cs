using Applikation.ApiResponse;
using Applikation.DTOs;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.Entities;
using Domain.AuthorAggregate.ValueObjects;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Update;

public class EditBookUseCase : IUseCase<IEditBookRequest, IResponse<BookDTO>>
{
    private readonly IAuthorRepository _authorRepo;

    public EditBookUseCase(IAuthorRepository authorRepo)
    {
        _authorRepo = authorRepo;
    }

    public IResponse<BookDTO> Execute(IEditBookRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<BookDTO>> ExecuteAsync(IEditBookRequest request)
    {
        try
        {
            var author = await _authorRepo.GetAuthorByIdAsync(AuthorId.Create(request.AuthorId));

            var bookToEdit = author.Books.FirstOrDefault(x => x.Id.Value == request.BookId);

            var bookWithEdits = Book.Create(
                BookId.Create(request.BookId),
                Title.Create(request.Title),
                PublishDate.Create(request.PublishDate),
                BasePrice.Create(request.BasePrice),
                AuthorId.Create(request.AuthorId), 
                CoverId.Create(request.CoverId));

            bookToEdit.Edit(bookWithEdits);

            var editedBookDTO = bookToEdit.TilDTO();

            await _authorRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse(editedBookDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<BookDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
