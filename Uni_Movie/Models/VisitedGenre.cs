using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Uni_Movie.Areas.Identity.Data;

namespace Uni_Movie.Models
{
    public class VisitedGenre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("genreId")]
        public int genreId { get; set; }
        public Genre genre { get; set; }
        public DateTime VisitDateTime { get; set; }
        public string userId{ get; set; }
        [ForeignKey("userId")]
        public ApplicationUser applicationUser { get; set; }
    }
}
