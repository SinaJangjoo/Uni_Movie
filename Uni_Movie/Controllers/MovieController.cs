using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
        }


    }
}
