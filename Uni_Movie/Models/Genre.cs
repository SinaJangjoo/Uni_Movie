using System.ComponentModel.DataAnnotations;

namespace Uni_Movie.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public List<Movie> movies { get; set; }
        public List<VisitedGenre> visitedGenres { get; set; }
    }
}
