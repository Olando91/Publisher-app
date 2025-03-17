using Applikation.ApiResponse;
using Applikation.DTOs.Book;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.AuthorAggregate.ValueObjects;
using Domain.BookAggregate;
using Domain.BookAggregate.ValueObjects;
using Domain.CoverAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Update;

public class EditBookUseCase : IUseCase<IEditBookRequest, IResponse<BookDTO>>
{
    private readonly IBookRepository _bookRepo;

    public EditBookUseCase(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IResponse<BookDTO> Execute(IEditBookRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<BookDTO>> ExecuteAsync(IEditBookRequest request)
    {
        try
        {
            var bookToEdit = await _bookRepo.GetBookByIdAsync(BookId.Create(request.BookId));

            bookToEdit.Edit(Title.Create(request.Title),
                PublishDate.Create(request.PublishDate),
                BasePrice.Create(request.BasePrice));

            var editedBookDTO = bookToEdit.TilDTO();

            await _bookRepo.SaveChangesAsync();

            return new ResponseBuilder().CreateSuccessResponse(editedBookDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<BookDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
