using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {

        private readonly IRaceRepository _repo;
        public RaceController(IRaceRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Race> races = await _repo.GetAllAsync();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race? race = await _repo.GetAsync(id);

            return View(race);
        }
    }
}
