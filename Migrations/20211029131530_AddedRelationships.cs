using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumStore.Migrations
{
    public partial class AddedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "ArtistDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistDescriptions_ArtistID",
                table: "ArtistDescriptions",
                column: "ArtistID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistDescriptions_Artists_ArtistID",
                table: "ArtistDescriptions",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistDescriptions_Artists_ArtistID",
                table: "ArtistDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_ArtistDescriptions_ArtistID",
                table: "ArtistDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "ArtistDescriptions");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Albums");
        }
    }
}
