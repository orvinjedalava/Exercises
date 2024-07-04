using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _repo;
        public ClubController(IClubRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Club> clubs = await _repo.GetAllAsync();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club? club = await _repo.GetAsync(id);
            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }
            await _repo.AddAsync(club);
            return RedirectToAction(nameof(Index));
        }
    }
}
