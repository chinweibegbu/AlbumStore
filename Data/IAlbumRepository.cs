using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IAlbumRepository
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public void CreateAlbum(Album album);
        public void UpdateAlbum(Album album);
        public void DeleteAlbum(Album album);
        public void SaveChanges();
        public void SetGenres(int albumId, string[] genres);
        public void DeleteAlbumGenres(int albumId);
        public IEnumerable<Album> Search(string? name, string[]? genres, string? artist);
    }
}
