using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    interface IArtistDescriptionDescriptionRepository
    {
        public IEnumerable<ArtistDescription> GetAllArtistDescriptions();
        public ArtistDescription GetArtistDescriptionById();
        public void CreateArtistDescription();
        public void UpdateArtistDescription();
        public void DeleteArtistDescription();
        public void SaveChanges();
    }
}
