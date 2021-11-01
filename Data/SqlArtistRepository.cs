using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Data
{
    class SqlArtistRepository : IArtistRepository
    {
        private readonly AlbumStoreContext _context;

        public SqlArtistRepository(AlbumStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _context.Artists.Include(artist => artist.Albums).ToList();
        }

        public IEnumerable<Artist> GetAllSoloArtists()
        {
            return _context.Artists.Where(a => EF.Property<string>(a, "Discriminator") == "SoloArtist");
        }

        public Artist GetArtistById(int id)
        {
            return _context.Artists.FirstOrDefault(a => a.ArtistId == id);
        }

        public void CreateArtist(Artist artist)
        {
            _context.Artists.Add(artist);
        }

        public void CreateSoloArtist(SoloArtist soloArtist)
        {
            _context.Artists.Add(soloArtist);
        }

        public void UpdateArtist(Artist artist)
        {
            // Empty
        }

        public void DeleteArtist(Artist artist)
        {
            _context.Artists.Remove(artist);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
