using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumStore.Migrations
{
    public partial class UpdatedMusicGennrePK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "MusicGenres",
                newName: "MusicGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MusicGenreId",
                table: "MusicGenres",
                newName: "GenreId");
        }
    }
}
