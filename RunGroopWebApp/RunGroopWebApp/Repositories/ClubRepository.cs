using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Repositories
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;
        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Club>> GetAllAsync()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club?> GetAsync(int id)
        {
            return await _context.Clubs.Include(club => club.Address).FirstOrDefaultAsync(club => club.Id == id);
        }

        public async Task<Club> AddAsync(Club club)
        {
            await _context.Clubs.AddAsync(club);
            await _context.SaveChangesAsync();

            return club;
        }
    }
}
