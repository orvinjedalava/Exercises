using RunGroopWebApp.Models;

namespace RunGroopWebApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<List<Race>> GetAllAsync();
        Task<Race?> GetAsync(int id);
    }
}
