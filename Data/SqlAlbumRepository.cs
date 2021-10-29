using AlbumStore.Models;
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
            return _context.Albums.ToList();
        }

        public Album GetAlbumById(int Id)
        {
            Album album = new Album();

            return album;
        }

        public List<Album> GetAlbumsByArtist(string stageName)
        {
            List<Album> artistAlbums = new List<Album>();

            return artistAlbums;
        }

        public void CreateAlbum(Album album)
        {
            Album newAlbum = new Album();

            _context.Add(newAlbum);
        }

        public void UpdateAlbum(int id, Album album)
        {
            // Empty
        }

        public void DeleteAlbum(Album album)
        {
            Album albumToDelete = new Album();

            _context.Add(albumToDelete);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
