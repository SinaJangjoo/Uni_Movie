using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_Movie.Migrations
{
    /// <inheritdoc />
    public partial class fixName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visitedGenres_AspNetUsers_userId",
                table: "visitedGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_visitedGenres_Genres_genreId",
                table: "visitedGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visitedGenres",
                table: "visitedGenres");

            migrationBuilder.RenameTable(
                name: "visitedGenres",
                newName: "VisitedGenres");

            migrationBuilder.RenameIndex(
                name: "IX_visitedGenres_userId",
                table: "VisitedGenres",
                newName: "IX_VisitedGenres_userId");

            migrationBuilder.RenameIndex(
                name: "IX_visitedGenres_genreId",
                table: "VisitedGenres",
                newName: "IX_VisitedGenres_genreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitedGenres",
                table: "VisitedGenres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedGenres_AspNetUsers_userId",
                table: "VisitedGenres",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedGenres_Genres_genreId",
                table: "VisitedGenres",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitedGenres_AspNetUsers_userId",
                table: "VisitedGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitedGenres_Genres_genreId",
                table: "VisitedGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitedGenres",
                table: "VisitedGenres");

            migrationBuilder.RenameTable(
                name: "VisitedGenres",
                newName: "visitedGenres");

            migrationBuilder.RenameIndex(
                name: "IX_VisitedGenres_userId",
                table: "visitedGenres",
                newName: "IX_visitedGenres_userId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitedGenres_genreId",
                table: "visitedGenres",
                newName: "IX_visitedGenres_genreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visitedGenres",
                table: "visitedGenres",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_visitedGenres_AspNetUsers_userId",
                table: "visitedGenres",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_visitedGenres_Genres_genreId",
                table: "visitedGenres",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
