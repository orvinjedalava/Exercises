using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;
        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Race>> GetAllAsync()
        {
            return await _context.Races.ToListAsync();
        }

        public async Task<Race?> GetAsync(int id)
        {
            return await _context.Races.Include(race => race.Address).FirstOrDefaultAsync();
        }
    }
}
