using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    interface IAlbumRepository
    {
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbumById();
        public List<Album> GetAlbumsByArtist();
        public void CreateAlbum();
        public void UpdateAlbum();
        public void DeleteAlbum();
        public void SaveChanges();
    }
}
