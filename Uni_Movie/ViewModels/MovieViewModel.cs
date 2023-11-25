using System.ComponentModel.DataAnnotations;

namespace Uni_Movie.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime Year { get; set; }
        [Required]
        public IFormFile MovieImage { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rate { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public int genreId { get; set; }
    }
}
