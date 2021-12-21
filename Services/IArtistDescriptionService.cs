using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public interface IArtistDescriptionService
    {
        public IEnumerable<ArtistDescription> GetAllArtistDescriptions();
        public ArtistDescription GetArtistDescriptionById(int id);
        public ArtistDescription CreateArtistDescription(ArtistDescription artist);
        public void UpdateArtistDescription(ArtistDescription artist);
        public void DeleteArtistDescription(ArtistDescription artist);
    }
}
