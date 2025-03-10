using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Applikation.UseCases.Create;
using Microsoft.AspNetCore.Mvc;
using Publisher_API.Requests;

namespace Publisher_API.Controllers;

[ApiController]
[Route("api/cover")]
public class CoverController : Controller
{
    private readonly IUseCase<IAddCoverRequest, IResponse<string>> _addCoverUseCase;

    public CoverController(IUseCase<IAddCoverRequest, IResponse<string>> addCoverUseCase)
    {
        _addCoverUseCase = addCoverUseCase;
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
}
