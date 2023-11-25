using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Uni_Movie.Data;
using Uni_Movie.Models;

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
			IEnumerable<Movie> movies = _dbContext.Movies.Include(x => x.genre).ToList();
			return View(movies);
		}

	}
}