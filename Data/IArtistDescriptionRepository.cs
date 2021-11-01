using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Data
{
    public interface IArtistDescriptionRepository
    {
        public IEnumerable<ArtistDescription> GetAllArtistDescriptions();
        public ArtistDescription GetArtistDescriptionById(int id);
        public void CreateArtistDescription(ArtistDescription artistDescription);
        public void UpdateArtistDescription(ArtistDescription artistDescription);
        public void DeleteArtistDescription(ArtistDescription artistDescription);
        public void SaveChanges();
    }
}
