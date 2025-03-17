using Applikation.ApiResponse;
using Applikation.DTOs.Artist;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Applikation.UseCases.Create;
using Applikation.UseCases.Delete;
using Applikation.UseCases.Read;
using Applikation.UseCases.Update;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Publisher_API.Requests;

namespace Publisher_API.Controllers;

[ApiController]
[Route("api/artist")]
public class ArtistController : Controller
{
    private readonly IUseCase<IAddArtistRequest, IResponse<string>> _addArtistUseCase;
    private readonly IUseCase<IGetArtistByIdRequest, IResponse<ArtistDTO>> _getArtistByIdUseCase;
    private readonly IUseCase<IDeleteArtistByIdRequest, IResponse<string>> _deleteArtistByIdUseCase;
    private readonly IUseCase<IGetAllArtistsRequest, IResponse<List<ArtistDTO>>> _getAllArtistsUseCase;
    private readonly IUseCase<IEditArtistRequest, IResponse<ArtistDTO>> _editArtistUseCase;

    public ArtistController(IUseCase<IAddArtistRequest, IResponse<string>> addArtistUseCase, IUseCase<IGetArtistByIdRequest, IResponse<ArtistDTO>> getArtistByIdUseCase, IUseCase<IDeleteArtistByIdRequest, IResponse<string>> deleteArtistByIdUseCase, IUseCase<IGetAllArtistsRequest, IResponse<List<ArtistDTO>>> getAllArtistsUseCase, IUseCase<IEditArtistRequest, IResponse<ArtistDTO>> editArtistUseCase)
    {
        _addArtistUseCase = addArtistUseCase;
        _getArtistByIdUseCase = getArtistByIdUseCase;
        _deleteArtistByIdUseCase = deleteArtistByIdUseCase;
        _getAllArtistsUseCase = getAllArtistsUseCase;
        _editArtistUseCase = editArtistUseCase;
    }

    [HttpPost("add-artist")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddArtist([FromBody] AddArtistRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _addArtistUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }


    [HttpGet("get-artist-by-id")]
    [ProducesResponseType(typeof(Response<ArtistDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetArtistById([FromQuery] GetArtistByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _getArtistByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }


    [HttpDelete("delete-artist-by-id")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteArtistById([FromQuery] DeleteArtistByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _deleteArtistByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-all-artists")]
    [ProducesResponseType(typeof(Response<List<ArtistDTO?>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllArtists([FromQuery] GetAllArtistsRequest request)
    {
        var apiResponse = await _getAllArtistsUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("edit-artist")]
    [ProducesResponseType(typeof(Response<ArtistDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> EditAuthor([FromBody] EditArtistRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _editArtistUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }
}
