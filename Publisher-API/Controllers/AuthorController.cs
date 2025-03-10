using Applikation.ApiResponse;
using Applikation.DTOs;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Microsoft.AspNetCore.Mvc;
using Publisher_API.Requests;

namespace Publisher_API.Controllers;

[ApiController]
[Route("api/author")]
public class AuthorController : Controller
{
    private readonly IUseCase<IAddAuthorRequest, IResponse<string>> _addAuthorUseCase;
    private readonly IUseCase<IGetAuthorByIdRequest, IResponse<AuthorDTO?>> _getAuthorByIdUseCase;
    private readonly IUseCase<IDeleteAuthorByIdRequest, IResponse<string>> _deleteAuthorByIdUseCase;
    private readonly IUseCase<IGetAllAuthorsRequest, IResponse<List<AuthorDTO>>> _getAllAuthorsUseCase;
    private readonly IUseCase<IEditAuthorRequest, IResponse<AuthorDTO>> _editAuthorUseCase;
    public AuthorController(IUseCase<IAddAuthorRequest, IResponse<string>> addAuthorUseCase, IUseCase<IGetAuthorByIdRequest, IResponse<AuthorDTO?>> getAuthorByIdUseCase, IUseCase<IDeleteAuthorByIdRequest, IResponse<string>> deleteAuthorByIdUseCase, IUseCase<IGetAllAuthorsRequest, IResponse<List<AuthorDTO>>> getAllAuthorsUseCase, IUseCase<IEditAuthorRequest, IResponse<AuthorDTO>> editAuthorUseCase)
    {
        _addAuthorUseCase = addAuthorUseCase;
        _getAuthorByIdUseCase = getAuthorByIdUseCase;
        _deleteAuthorByIdUseCase = deleteAuthorByIdUseCase;
        _getAllAuthorsUseCase = getAllAuthorsUseCase;
        _editAuthorUseCase = editAuthorUseCase;
    }

    [HttpPost("add-author")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _addAuthorUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-author-by-id")]
    [ProducesResponseType(typeof(Response<AuthorDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAuthorById([FromQuery] GetAuthorByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _getAuthorByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpDelete("delete-author-by-id")]
    [ProducesResponseType(typeof(Response<AuthorDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAuthorById([FromQuery] DeleteAuthorByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _deleteAuthorByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-all-authors")]
    [ProducesResponseType(typeof(Response<List<AuthorDTO?>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAuthors([FromQuery] GetAllAuthorsRequest request)
    {
        var apiResponse = await _getAllAuthorsUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("edit-author")]
    [ProducesResponseType(typeof(Response<AuthorDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> EditAuthor([FromBody] EditAuthorRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _editAuthorUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

}
