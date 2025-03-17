using Applikation.ApiResponse;
using Applikation.DTOs.Book;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.BookAggregate.ValueObjects;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetBookByIdUseCase : IUseCase<IGetBookByIdRequest, IResponse<BookDTO>>
{
    private readonly IBookRepository _bookRepo;

    public GetBookByIdUseCase(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IResponse<BookDTO> Execute(IGetBookByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<BookDTO>> ExecuteAsync(IGetBookByIdRequest request)
    {
        try
        {
            var book = await _bookRepo.GetBookByIdAsync(BookId.Create(request.BookId));

            var bookDTO = book.TilDTO();

            return new ResponseBuilder().CreateSuccessResponse(bookDTO, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<BookDTO>(HttpStatusCode.InternalServerError, e);
        }
    }
}
