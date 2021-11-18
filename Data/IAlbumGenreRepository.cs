using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IAlbumGenreRepository
    {
        public IEnumerable<AlbumGenre> GetAllAlbumGenres();
        public AlbumGenre GetAlbumGenreById(int id);
        public void CreateAlbumGenre(AlbumGenre albumGenre);
        public void UpdateAlbumGenre(AlbumGenre albumGenre);
        public void DeleteAlbumGenre(AlbumGenre albumGenre);
        public void SaveChanges();
    }
}
