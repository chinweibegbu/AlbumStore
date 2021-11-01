using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Data
{
    class SqlAlbumRepository : IAlbumRepository
    {
        private readonly AlbumStoreContext _context;

        public SqlAlbumRepository(AlbumStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _context.Albums.Include(album => album.Artist).ToList();
        }

        public Album GetAlbumById(int id)
        {
            return _context.Albums.Include(album => album.Artist).FirstOrDefault(a => a.AlbumId == id);
        }

        public List<Album> GetAlbumsByArtist(string stageName)
        {
            List<Album> artistAlbums = new List<Album>();

            return artistAlbums;
        }

        public void CreateAlbum(Album album)
        {
            _context.Albums.Add(album);
        }

        public void UpdateAlbum(Album album)
        {
            // Empty
        }

        public void DeleteAlbum(Album album)
        {
            _context.Albums.Remove(album);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
