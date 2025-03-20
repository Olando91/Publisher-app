using Domain.UserAggregate;

namespace Applikation.Porte.Udgående;

public interface IAuthRepository
{
    Task<User> GetUserByLoginAsync(string username, string password);
    Task RemoveRefreshTokenByUserIdAsync(int userId);

    Task AddRefreshTokenAsync(RefreshToken refreshToken);

    Task<RefreshToken> GetRefreshTokenAsync(string refreshToken);

}
