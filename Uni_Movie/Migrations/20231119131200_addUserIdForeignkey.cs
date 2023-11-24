using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uni_Movie.Migrations
{
    /// <inheritdoc />
    public partial class addUserIdForeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "VisitedGenre",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitedGenre_userId",
                table: "VisitedGenre",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitedGenre_AspNetUsers_userId",
                table: "VisitedGenre",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitedGenre_AspNetUsers_userId",
                table: "VisitedGenre");

            migrationBuilder.DropIndex(
                name: "IX_VisitedGenre_userId",
                table: "VisitedGenre");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "VisitedGenre");
        }
    }
}
