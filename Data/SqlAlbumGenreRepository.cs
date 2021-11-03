using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public class AlbumGenreRepository : IAlbumGenreRepository
    {
        public IEnumerable<AlbumGenre> GetAllAlbumGenres()
        {
            return new List<AlbumGenre>();
        }

        public AlbumGenre GetAlbumGenreById(int id)
        {
            return new AlbumGenre();
        }

        public void CreateAlbumGenre(AlbumGenre albumGenre)
        {

        }

        public void UpdateAlbumGenre(AlbumGenre albumGenre)
        {

        }

        public void DeleteAlbumGenre(AlbumGenre albumGenre)
        {

        }

        public void SaveChanges()
        {

        }
    }
}
