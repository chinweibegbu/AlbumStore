using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumStore.Data
{
    public class AlbumStoreContext : DbContext
    {
        public AlbumStoreContext(DbContextOptions<AlbumStoreContext> opt) : base(opt)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<SoloArtist> SoloArtists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }
        public DbSet<ArtistDescription> ArtistDescriptions { get; set; }
    }
}
