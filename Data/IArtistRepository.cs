using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IArtistRepository
    {
        public IEnumerable<Artist> GetAllArtists();
        public IEnumerable<Artist> GetAllSoloArtists();
        public Artist GetArtistById(int id);
        public void CreateArtist(Artist artist);
        public void CreateSoloArtist(SoloArtist soloArtist);
        public void UpdateArtist(Artist artist);
        public void DeleteArtist(Artist artist);
        public void SaveChanges();
    }
}
