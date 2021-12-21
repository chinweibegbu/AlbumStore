using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IAlbumGenreRepository
    {
        public IEnumerable<AlbumGenre> GetAllAlbumGenres();
        public AlbumGenre GetAlbumGenreById(int id);
    }
}
