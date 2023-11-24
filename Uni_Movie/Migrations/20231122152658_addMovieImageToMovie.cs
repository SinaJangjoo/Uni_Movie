using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_Movie.Migrations
{
    /// <inheritdoc />
    public partial class addMovieImageToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MovieImage",
                table: "Movies",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieImage",
                table: "Movies");
        }
    }
}
