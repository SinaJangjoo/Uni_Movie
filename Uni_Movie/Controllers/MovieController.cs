using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uni_Movie.Data;
using Uni_Movie.Models;
using Uni_Movie.ViewModels;

namespace Uni_Movie.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Movie> movies;
            movies = _dbContext.Movies.Include(x => x.genre).ToList();
            return View(movies);
        }

        public IActionResult Create()
        {
            MovieCreateViewModel model = new()
            {
                movie = new(),
                genreList = _dbContext.Genres.Select(x => new SelectListItem   // For Dropdown
                {
                    Text = x.Title,
                    Value = x.Id.ToString()
                })
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new()
                {
                    Title = model.movie.Title,
                    Description = model.movie.Description,
                    Director = model.movie.Director,
                    genreId = model.movie.genreId,
                    Rate = model.movie.Rate,
                    Year = model.movie.Year
                };
                if (model.movie.MovieImage != null)
                {
                    string extension = Path.GetExtension(model.movie.MovieImage.FileName).ToLower();  //It will gives us the FilemName of type (IFormFile)
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {
                        if (model.movie.MovieImage.Length <= 5 * Math.Pow(1024, 2))
                        {
                            byte[] buffer = new byte[model.movie.MovieImage.Length];
                            model.movie.MovieImage.OpenReadStream().Read(buffer, 0, buffer.Length);
                            movie.MovieImage = buffer;
                        }
                    }
                }
                _dbContext.Add(movie);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            Movie movie = await _dbContext.Movies.FindAsync(id);
            if (movie != null)
            {
                MovieUpdateViewModel model = new()
                {
                    movie = new()
                    {
                        Title = movie.Title,
                        Year = movie.Year,
                        Director = movie.Director,
                        Rate = movie.Rate,
                        Description = movie.Description,
                        Id = id,
                        Image = movie.MovieImage,
                        genreId = movie.genreId
                    },
                    genreList = await _dbContext.Genres.ToListAsync()
                };
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(MovieUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new()
                {
                    Id = model.movie.Id,
                    Title = model.movie.Title,
                    Year = model.movie.Year,
                    Director = model.movie.Director,
                    Rate = model.movie.Rate,
                    Description = model.movie.Description,
                    genreId = model.movie.genreId
                };
                if (model.movie.MovieImage != null)
                {
                    string extension = Path.GetExtension(model.movie.MovieImage.FileName).ToLower();  //It will gives us the FilemName of type (IFormFile)
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                    {
                        if (model.movie.MovieImage.Length <= 5 * Math.Pow(1024, 2))
                        {
                            byte[] buffer = new byte[model.movie.MovieImage.Length];
                            model.movie.MovieImage.OpenReadStream().Read(buffer, 0, buffer.Length);
                            movie.MovieImage = buffer;
                        }
                    }
                }
                _dbContext.Update(movie);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                if (model.movie.MovieImage == null)
                {
                    Movie movie = new()
                    {
                        Id = model.movie.Id,
                        Title = model.movie.Title,
                        Year = model.movie.Year,
                        Director = model.movie.Director,
                        Rate = model.movie.Rate,
                        Description = model.movie.Description,
                        genreId = model.movie.genreId,
                        MovieImage = model.movie.Image
                    };
                    _dbContext.Update(movie);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var movie = _dbContext.Movies.Find(id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
