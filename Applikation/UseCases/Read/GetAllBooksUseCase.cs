using Applikation.ApiResponse;
using Applikation.DTOs.Book;
using Applikation.ExtensionMetoder;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using System.Net;

namespace Applikation.UseCases.Read;

public class GetAllBooksUseCase : IUseCase<IGetAllBooksRequest, IResponse<List<BookDTO>>>
{
    private readonly IBookRepository _bookRepo;

    public GetAllBooksUseCase(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IResponse<List<BookDTO>> Execute(IGetAllBooksRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<IResponse<List<BookDTO>>> ExecuteAsync(IGetAllBooksRequest request)
    {
        try
        {
            var books = await _bookRepo.GetAllBooksAsync();

            var bookDTOs = books.Select(b => b.TilDTO()).ToList();

            return new ResponseBuilder().CreateSuccessResponse(bookDTOs, HttpStatusCode.OK);
        }
        catch (Exception e)
        {
            return new ResponseBuilder().CreateErrorResponse<List<BookDTO>>(HttpStatusCode.InternalServerError, e);
        }
    }
}
