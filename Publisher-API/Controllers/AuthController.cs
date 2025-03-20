using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.RequestInterfaces;
using Microsoft.AspNetCore.DataProtection;
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
            var token = GenerateJwtToken(request.Username, isRefreshToken: false);
            var refreshtoken = GenerateJwtToken(request.Username, isRefreshToken: true);
            return Ok(new LoginResponseModel
            {
                Token = token,
                RefreshToken = refreshtoken,
                TokenExpired = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds()
            });
        }
        return null;
    }

    [HttpGet("login-by-refresh-token")]
    public ActionResult<LoginResponseModel> LoginByRefreshToken(string refreshToken)
    {
        var secret = configuration.GetValue<string>("Jwt:RefreshTokenSecret");
        var claimsPricipal = GetClaimsPrincipalFromToken(refreshToken, secret);
        if (claimsPricipal == null)
        {
            return new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }
        var username = claimsPricipal.FindFirstValue(ClaimTypes.NameIdentifier);
        // Kontroller om user er gyldig

        var newToken = GenerateJwtToken(username, isRefreshToken: false);
        var newRefreshToken = GenerateJwtToken(username, isRefreshToken: true);

        return new LoginResponseModel
        {
            Token = newToken,
            TokenExpired = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
            RefreshToken = newRefreshToken,
        };
    }

    private ClaimsPrincipal GetClaimsPrincipalFromToken(string token, string secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        try
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = "Lasse",
                ValidateIssuer = true,
                ValidIssuer = "Lasse",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out var validatedToken);
            return principal;
        }
        catch
        {
            return null;
        }
    }

    private string GenerateJwtToken(string username, bool isRefreshToken)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        string secret = configuration.GetValue<string>($"Jwt:{(isRefreshToken ? "RefreshTokenSecret" : "Secret")}");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Lasse", 
            audience: "Lasse", 
            claims: claims, 
            expires: DateTime.UtcNow.AddHours(isRefreshToken ? 24 : 1), 
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
