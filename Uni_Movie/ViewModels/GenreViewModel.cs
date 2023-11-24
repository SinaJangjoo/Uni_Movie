using Uni_Movie.Models;

namespace Uni_Movie.ViewModels
{
    public class GenreViewModel
    {
        public IEnumerable<Genre> genres { get; set; }
        public Genre genre { get; set; }
    }
}
