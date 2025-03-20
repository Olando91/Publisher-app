using Applikation.ApiResponse;
using Applikation.Porte.Indgående;
using Applikation.Porte.Udgående;
using Applikation.RequestInterfaces;
using Domain.UserAggregate;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Publisher_API.AuthenticationModels;
using Publisher_API.Requests;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Publisher_API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthController(IConfiguration configuration, IAuthRepository authRepo) : ControllerBase
{
    
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginModel request)
    {
        var user = await authRepo.GetUserByLoginAsync(request.Username, request.Password);
        if (user != null)
        {
            var token = GenerateJwtToken(user, isRefreshToken: false);
            var refreshtoken = GenerateJwtToken(user, isRefreshToken: true);

            await authRepo.AddRefreshTokenAsync(new RefreshToken
            {
                Token = refreshtoken,
                UserId = user.Id
            });

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
    public async Task<ActionResult<LoginResponseModel>> LoginByRefreshToken(string request)
    {
        var refreshToken = await authRepo.GetRefreshTokenAsync(request);
        if (refreshToken == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        var newToken = GenerateJwtToken(refreshToken.User, isRefreshToken: false);
        var newRefreshToken = GenerateJwtToken(refreshToken.User, isRefreshToken: true);

        await authRepo.AddRefreshTokenAsync(new RefreshToken
        {
            Token = newRefreshToken,
            UserId = refreshToken.UserId
        });

        return new LoginResponseModel
        {
            Token = newToken,
            TokenExpired = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(),
            RefreshToken = newRefreshToken,
        };
    }


    private string GenerateJwtToken(User user, bool isRefreshToken)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Username)
        };
        claims.AddRange(user.UserRoles.Select(x => new Claim(ClaimTypes.Role, x.Role.RoleName)));

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
