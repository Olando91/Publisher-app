using Applikation.ApiResponse;
using Applikation.DTOs;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Applikation.UseCases.Create;
using Applikation.UseCases.Delete;
using Applikation.UseCases.Read;
using Applikation.UseCases.Update;
using Microsoft.AspNetCore.Mvc;
using Publisher_API.Requests;

namespace Publisher_API.Controllers;

[ApiController]
[Route("api/cover")]
public class CoverController : Controller
{
    private readonly IUseCase<IAddCoverRequest, IResponse<string>> _addCoverUseCase;
    private readonly IUseCase<IGetCoverByIdRequest, IResponse<CoverDTO>> _getCoverByIdUseCase;
    private readonly IUseCase<IDeleteCoverByIdRequest, IResponse<string>> _deleteCoverByIdUseCase;
    private readonly IUseCase<IGetAllCoversRequest, IResponse<List<CoverDTO>>> _getAllCoversUseCase;
    private readonly IUseCase<IEditCoverRequest, IResponse<CoverDTO>> _editCoverUseCase;
    private readonly IUseCase<IAddArtistToCoverRequest, IResponse<CoverDTO>> _addArtistToCoverUseCase;
    private readonly IUseCase<IRemoveArtistFromCoverRequest, IResponse<CoverDTO>> _removeArtistFromCoverUseCase;

    public CoverController(IUseCase<IAddCoverRequest, IResponse<string>> addCoverUseCase, IUseCase<IGetCoverByIdRequest, IResponse<CoverDTO>> getCoverByIdUseCase, IUseCase<IDeleteCoverByIdRequest, IResponse<string>> deleteCoverByIdUseCase, IUseCase<IGetAllCoversRequest, IResponse<List<CoverDTO>>> getAllCoversUseCase, IUseCase<IEditCoverRequest, IResponse<CoverDTO>> editCoverUseCase, IUseCase<IAddArtistToCoverRequest, IResponse<CoverDTO>> addArtistToCoverUseCase, IUseCase<IRemoveArtistFromCoverRequest, IResponse<CoverDTO>> removeArtistFromCoverUseCase)
    {
        _addCoverUseCase = addCoverUseCase;
        _getCoverByIdUseCase = getCoverByIdUseCase;
        _deleteCoverByIdUseCase = deleteCoverByIdUseCase;
        _getAllCoversUseCase = getAllCoversUseCase;
        _editCoverUseCase = editCoverUseCase;
        _addArtistToCoverUseCase = addArtistToCoverUseCase;
        _removeArtistFromCoverUseCase = removeArtistFromCoverUseCase;
    }

    [HttpPost("add-cover")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddCover([FromBody] AddCoverRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _addCoverUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-cover-by-id")]
    [ProducesResponseType(typeof(Response<CoverDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCoverById([FromQuery] GetCoverByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _getCoverByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpDelete("delete-cover-by-id")]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCoverById([FromQuery] DeleteCoverByIdRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _deleteCoverByIdUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpGet("get-all-covers")]
    [ProducesResponseType(typeof(Response<List<CoverDTO?>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllCovers([FromQuery] GetAllCoversRequest request)
    {
        var apiResponse = await _getAllCoversUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("edit-cover")]
    [ProducesResponseType(typeof(Response<CoverDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> EditCover([FromBody] EditCoverRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _editCoverUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("add-artist-to-cover")]
    [ProducesResponseType(typeof(Response<CoverDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddArtistToCover([FromBody] AddArtistToCoverRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _addArtistToCoverUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("remove-artist-from-cover")]
    [ProducesResponseType(typeof(Response<CoverDTO?>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveArtistFromCover([FromBody] RemoveArtistFromCoverRequest request)
    {
        if (!request.RequestIsValid())
            return new ObjectResult(new object()) { StatusCode = StatusCodes.Status400BadRequest };

        var apiResponse = await _removeArtistFromCoverUseCase.ExecuteAsync(request);

        return new ObjectResult(apiResponse) { StatusCode = StatusCodes.Status200OK };
    }
}
