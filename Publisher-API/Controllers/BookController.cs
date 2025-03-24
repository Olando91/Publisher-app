using Applikation.ApiResponse;
using Applikation.DTOs.Book;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Publisher_API.Requests;

namespace Publisher_API.Controllers;

[Authorize]
[ApiController]
[Route("api/book")]
public class BookController : Controller
{
    private readonly IUseCase<IAddBookRequest, IResponse<string>> _addBookUseCase;
    private readonly IUseCase<IEditBookRequest, IResponse<BookDTO>> _editBookUseCase;
    private readonly IUseCase<IDeleteBookRequest, IResponse<string>> _deleteBookUseCase;
    private readonly IUseCase<IGetBookByIdRequest, IResponse<BookDTO>> _getBookByIdUseCase;
    private readonly IUseCase<IGetAllBooksRequest, IResponse<List<BookDTO>>> _getAllBooksUseCase;

    public BookController(IUseCase<IAddBookRequest, IResponse<string>> addBookUseCase, IUseCase<IEditBookRequest, IResponse<BookDTO>> editBookUseCase, IUseCase<IDeleteBookRequest, IResponse<string>> deleteBookUseCase, IUseCase<IGetBookByIdRequest, IResponse<BookDTO>> getBookByIdUseCase, IUseCase<IGetAllBooksRequest, IResponse<List<BookDTO>>> getAllBooksUseCase)
    {
        _addBookUseCase = addBookUseCase;
        _editBookUseCase = editBookUseCase;
        _deleteBookUseCase = deleteBookUseCase;
        _getBookByIdUseCase = getBookByIdUseCase;
        _getAllBooksUseCase = getAllBooksUseCase;
    }

    [HttpPost("add-book")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddBook([FromBody] AddBookRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _addBookUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-book-by-id")]
    [ProducesResponseType(typeof(Response<BookDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetBookById([FromQuery] GetBookByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _getBookByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("edit-book")]
    [ProducesResponseType(typeof(Response<BookDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> EditBook([FromBody] EditBookRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _editBookUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpDelete("delete-book-by-id")]
    [ProducesResponseType(typeof(Response<BookDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBook([FromQuery] DeleteBookRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _deleteBookUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-all-books")]
    [ProducesResponseType(typeof(Response<List<BookDTO?>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAuthors([FromQuery] GetAllBooksRequest request)
    {
        var apiResponse = await _getAllBooksUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }
}
