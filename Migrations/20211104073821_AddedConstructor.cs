using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumStore.Migrations
{
    public partial class AddedConstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AlbumGenres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AlbumGenres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
