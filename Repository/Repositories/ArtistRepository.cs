using Applikation.Porte.Udgående;
using Domain.ArtistAggregate;
using Domain.ArtistAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly PublisherDBContext _dbContext;

        public ArtistRepository(PublisherDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddArtistAsync(Artist artist)
        {
            try
            {
                await _dbContext.Artists.AddAsync(artist);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteArtistByIdAsync(ArtistId id)
        {
            try
            {
                var artist = await _dbContext.Artists
                    .Include(x => x.Covers)
                    .ThenInclude(x => x.Artists)
                    .FirstOrDefaultAsync(x => x.Id == id);

                var orphanedCovers = artist.Covers
                    .Where(c => c.Artists.Count == 1)
                    .ToList();

                _dbContext.Covers.RemoveRange(orphanedCovers);

                _dbContext.Artists.Remove(artist);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Artist>> GetAllArtistsAsync()
        {
            try
            {
                var artists = await _dbContext.Artists
                    .Include(a => a.Covers)
                    .ThenInclude(c => c.Book)
                    .ThenInclude(b => b.Author)
                    .ToListAsync();
                return artists;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Artist> GetArtistByIdAsync(ArtistId id)
        {
            try
            {
                var artist = await _dbContext.Artists
                    .Include(a => a.Covers)
                    .ThenInclude(c => c.Book)
                    .ThenInclude(b => b.Author)
                    .FirstOrDefaultAsync(a => a.Id == id);
                return artist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Artist>> GetArtistsById(List<ArtistId> artistIds)
        {
            try
            {
                var artists = new List<Artist>();
                foreach (var artistId in artistIds)
                {
                    artists.Add(await _dbContext.Artists
                    .Include(a => a.Covers)
                    .FirstOrDefaultAsync(a => a.Id == artistId));
                }
                return artists;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
