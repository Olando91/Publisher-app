using Applikation.Porte.Udgående;
using Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly PublisherDBContext _dbContext;

    public AuthRepository(PublisherDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByLoginAsync(string username, string password)
    {
        return await _dbContext.Users
            .Include(u => u.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }

    public async Task RemoveRefreshTokenByUserIdAsync(int userId)
    {
        var refreshToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        if (refreshToken != null)
        {
            _dbContext.RemoveRange(refreshToken);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _dbContext.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<RefreshToken> GetRefreshTokenAsync(string refreshToken)
    {
        return await _dbContext.RefreshTokens
            .Include(x => x.User)
            .ThenInclude(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Token == refreshToken);
    }
}
