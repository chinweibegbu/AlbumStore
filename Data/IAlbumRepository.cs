using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IAlbumRepository
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public List<Album> GetAlbumsByArtist(string name);
        public void CreateAlbum(Album album);
        public void UpdateAlbum(int id, Album album);
        public void DeleteAlbum(Album album);
        public void SaveChanges();
    }
}
