using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uni_Movie.Data;
using Uni_Movie.Models;
using Uni_Movie.Utilities;
using Uni_Movie.ViewModels;

namespace Uni_Movie.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task< IActionResult> Index(GenreViewModel model)
        {
            var Vm=new GenreViewModel();
            Vm.genres = new List<Genre>();
            Vm.genres=await _dbContext.Genres.ToListAsync();
            if (Vm.genres.Any() == false || Vm.genres == null)
            {
                return NotFound();
            }
            else
            {
                return View(Vm);
            }
        }

        
        public IActionResult Create(GenreViewModel model)
        {
            Genre genre = new Genre() { Title = model.genre.Title };
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var genre = _dbContext.Genres.FirstOrDefault(u => u.Id == id);
            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
            return Json(new {success=true});
        }
    }
}
