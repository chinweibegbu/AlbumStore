using AlbumStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Data
{
    public class SqlAlbumGenreRepository : IAlbumGenreRepository
    {
        private readonly AlbumStoreContext _context;

        public SqlAlbumGenreRepository(AlbumStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<AlbumGenre> GetAllAlbumGenres()
        {
            return _context.AlbumGenres.ToList();
        }

        public AlbumGenre GetAlbumGenreById(int id)
        {
            return _context.AlbumGenres.FirstOrDefault(ag => ag.AlbumGenreId == id);
        }

        public void CreateAlbumGenre(AlbumGenre albumGenre)
        {
            _context.AlbumGenres.Add(albumGenre);
        }

        public void UpdateAlbumGenre(AlbumGenre albumGenre)
        {
            // Empty
        }

        public void DeleteAlbumGenre(AlbumGenre albumGenre)
        {
            _context.AlbumGenres.Remove(albumGenre);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
