using Applikation.Porte.Udgående;
using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories;

public class CoverRepository : ICoverRepository
{
    private readonly PublisherDBContext _dbContext;

    public CoverRepository(PublisherDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCoverAsync(Cover cover)
    {
        try
        {
            await _dbContext.Covers.AddAsync(cover);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteCoverByIdAsync(CoverId coverId)
    {
        try
        {
            var coverToDelete = await _dbContext.Covers.FindAsync(coverId);
             _dbContext.Covers.Remove(coverToDelete);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<Cover>> GetAllCoversAsync()
    {
        try
        {
            var covers = await _dbContext.Covers
                .Include(c => c.Artists)
                .ToListAsync();
            return covers;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Cover> GetCoverByIdAsync(CoverId coverId)
    {
        try
        {
            var cover = await _dbContext.Covers
                .Include(c => c.Artists)
                .FirstOrDefaultAsync(c => c.Id == coverId);
            return cover;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
