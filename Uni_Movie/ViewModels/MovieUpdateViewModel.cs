using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uni_Movie.Models;

namespace Uni_Movie.ViewModels
{
    public class MovieUpdateViewModel
    {
        public MovieUpdateViewModel()
        {
            genreList = new List<Genre>();
        }
        public MovieViewModel movie { get; set; }

        [ValidateNever]
        public IEnumerable<Genre> genreList { get; set; }
    }
}
