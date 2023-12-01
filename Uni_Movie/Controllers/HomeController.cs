using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using Uni_Movie.Data;
using Uni_Movie.Models;
using Uni_Movie.ViewModels;

namespace Uni_Movie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                genreList = _dbContext.Genres
                .Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() }),
                movieList = _dbContext.Movies.Include(u => u.genre).ToList(),
                movie = null,
            };
            return View(model);
        }

        public async Task<IActionResult> SearchMovie(HomeViewModel viewModel)
        {
            if (String.IsNullOrEmpty(viewModel.movie.Title))
            {
                ModelState.AddModelError("Movie.Title", "Search title can not be empty");
                viewModel.genreList = _dbContext.Genres.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() });
                viewModel.movieList = _dbContext.Movies.Include(x => x.genre).ToList();
                viewModel.movie = null;
                return View("Index", viewModel);
            }
            if (viewModel.movie != null && !String.IsNullOrEmpty(viewModel.movie.Title))
            {
                var movies = await _dbContext.Movies.Where(x => x.Title.ToLower()
                .Contains(viewModel.movie.Title.ToLower())).Include(x => x.genre).ToListAsync();
                HomeViewModel model = new() { movieList = movies };
                if (model.movieList.Count() == 0)
                {
                    TempData["notFound"] = "! Nothing Found";
                    return View("Index", model);
                }
                else
                {
                    return View("Index", model);
                }
            }
            return RedirectToAction("Index", viewModel);
        }

        public async Task<IActionResult> Filter(HomeViewModel viewModel)
        {

            if (String.IsNullOrEmpty(viewModel.movie.Title))
            {
                ModelState.AddModelError("genreId", "Choose one Genre");
                //viewModel.movieList =await _dbContext.Movies.Where(x=>x.genreId==viewModel.movie.genreId)
                //    .Include(x => x.genre).ToListAsync();

                var movies = await _dbContext.Movies.Where(x => x.genreId == viewModel.movie.genreId)
                    .Include(x => x.genre).ToListAsync();
            if (viewModel.movie != null)
            {
                if (movies.Count > 0)
                {
                    HomeViewModel model = new() { movieList = movies };
                    return View("Index", model);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
               
            }
            return View("Index", viewModel);
            }

            return RedirectToAction("Index", viewModel);
        }

    }
}
