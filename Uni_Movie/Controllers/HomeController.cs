using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Uni_Movie.Models;

namespace Uni_Movie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}