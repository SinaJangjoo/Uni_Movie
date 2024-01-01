using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_Movie.Migrations
{
    /// <inheritdoc />
    public partial class addVisitedGenreModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitedGenre_AspNetUsers_userId",
                table: "VisitedGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitedGenre_Genres_genreId",
                table: "VisitedGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitedGenre",
                table: "VisitedGenre");

            migrationBuilder.RenameTable(
                name: "VisitedGenre",
                newName: "visitedGenres");

            migrationBuilder.RenameIndex(
                name: "IX_VisitedGenre_userId",
                table: "visitedGenres",
                newName: "IX_visitedGenres_userId");

            migrationBuilder.RenameIndex(
                name: "IX_VisitedGenre_genreId",
                table: "visitedGenres",
                newName: "IX_visitedGenres_genreId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "VisitedGenre");

            migrationBuilder.RenameIndex(
                name: "IX_visitedGenres_userId",
                table: "VisitedGenre",
                newName: "IX_VisitedGenre_userId");

            migrationBuilder.RenameIndex(
                name: "IX_visitedGenres_genreId",
                table: "VisitedGenre",
                newName: "IX_VisitedGenre_genreId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitedGenre",
                table: "VisitedGenre",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedGenre_AspNetUsers_userId",
                table: "VisitedGenre",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedGenre_Genres_genreId",
                table: "VisitedGenre",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
