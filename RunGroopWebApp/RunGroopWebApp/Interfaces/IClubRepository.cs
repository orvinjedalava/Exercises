using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IClubRepository
    {
        Task<List<Club>> GetAllAsync();
        Task<Club?> GetAsync(int id);
        Task<Club> AddAsync(Club club);
    }
}
