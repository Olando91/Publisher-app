using Applikation.ApiResponse;
using Applikation.DTOs.Book;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Microsoft.AspNetCore.Mvc;
using Publisher_API.Requests;

namespace Publisher_API.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class PublicController : Controller
    {
        private readonly IUseCase<IGetAllBooksRequest, IResponse<List<BookDTO>>> _getAllBooksUseCase;

        public PublicController(IUseCase<IGetAllBooksRequest, IResponse<List<BookDTO>>> getAllBooksUseCase)
        {
            _getAllBooksUseCase = getAllBooksUseCase;
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
}
