using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IAlbumRepository
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public IEnumerable<Album> GetAlbumsByArtist(string name);
        public void CreateAlbum(Album album);
        public void UpdateAlbum(Album album);
        public void DeleteAlbum(Album album);
        public void SaveChanges();
    }
}
