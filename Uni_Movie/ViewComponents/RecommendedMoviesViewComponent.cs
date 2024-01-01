using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Uni_Movie.Areas.Identity.Data;
using Uni_Movie.Data;
using Uni_Movie.Models;

namespace Uni_Movie.ViewComponents
{
    public class RecommendedMoviesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public RecommendedMoviesViewComponent(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
        {
            db = _db;
            userManager = _userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var result = db.VisitedGenres.Where(x => x.userId == user.Id).AsEnumerable()
                .GroupBy(x => x.genreId).OrderByDescending(x => x.AsQueryable().Count()).FirstOrDefault().ToList();

            var genreId = result.FirstOrDefault()?.genreId;
            var recomendMovie = db.Movies.Where(x => x.genreId == genreId).ToList();
            List<Movie> recomendedMovies = new ();
            for (int i = 0; i < 3; i++)
            {
                Random random = new();
                int rnd = random.Next(0, recomendMovie.Count - 1);
                recomendedMovies.Add(recomendMovie[rnd]);

            }
            return View(recomendedMovies);
        }
    }
}