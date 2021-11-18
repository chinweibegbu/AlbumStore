using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumStore.Migrations
{
    public partial class UpdatedAlbumGenreFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumGenres_MusicGenres_MusicGenreGenreId",
                table: "AlbumGenres");

            migrationBuilder.DropIndex(
                name: "IX_AlbumGenres_MusicGenreGenreId",
                table: "AlbumGenres");

            migrationBuilder.DropColumn(
                name: "MusicGenreGenreId",
                table: "AlbumGenres");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "AlbumGenres",
                newName: "MusicGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenres_MusicGenreId",
                table: "AlbumGenres",
                column: "MusicGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumGenres_MusicGenres_MusicGenreId",
                table: "AlbumGenres",
                column: "MusicGenreId",
                principalTable: "MusicGenres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumGenres_MusicGenres_MusicGenreId",
                table: "AlbumGenres");

            migrationBuilder.DropIndex(
                name: "IX_AlbumGenres_MusicGenreId",
                table: "AlbumGenres");

            migrationBuilder.RenameColumn(
                name: "MusicGenreId",
                table: "AlbumGenres",
                newName: "GenreId");

            migrationBuilder.AddColumn<int>(
                name: "MusicGenreGenreId",
                table: "AlbumGenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumGenres_MusicGenreGenreId",
                table: "AlbumGenres",
                column: "MusicGenreGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumGenres_MusicGenres_MusicGenreGenreId",
                table: "AlbumGenres",
                column: "MusicGenreGenreId",
                principalTable: "MusicGenres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
