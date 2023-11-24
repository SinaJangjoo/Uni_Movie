using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Uni_Movie.Areas.Identity.Data;
using Uni_Movie.Models;

namespace Uni_Movie.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Genre>().HasData(
            new Genre
            {
                Id = 1,
                Title = "Comedy"
            }, new Genre
            {
                Id = 2,
                Title = "Horror"
            }, new Genre
            {
                Id = 3,
                Title = "Sci-Fi"
            }, new Genre
            {
                Id = 4,
                Title = "Documentary"
            }, new Genre
            {
                Id = 5,
                Title = "Drama"
            });
    }
}
