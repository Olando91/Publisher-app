using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Publisher_API.AuthenticationModels;
using Publisher_API.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Publisher_API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthController(IConfiguration configuration) : ControllerBase
{

    [HttpPost("login")]
    public ActionResult<LoginResponseModel> Login([FromBody] LoginModel request)
    {
        if (request.Username == "Admin" && request.Password == "Admin")
        {
            var token = GenerateJwtToken(request.Username);
            return Ok(new LoginResponseModel { Token = token });
        }
        return null;
    }

    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        string secret = configuration.GetValue<string>("Jwt:Secret");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Lasse", 
            audience: "Lasse", 
            claims: claims, 
            expires: DateTime.UtcNow.AddHours(1), 
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
