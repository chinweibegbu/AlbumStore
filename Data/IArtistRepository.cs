using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    interface IArtistRepository
    {
        public IEnumerable<Artist> GetAllArtists();
        public IEnumerable<SoloArtist> GetAllSoloArtists();
        public Artist GetArtistById();
        public void CreateArtist();
        public void UpdateArtist();
        public void DeleteArtist();
        public void SaveChanges();
    }
}
