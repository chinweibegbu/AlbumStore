using AlbumStore.Data;
using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public class ArtistDescriptionService : IArtistDescriptionService
    {
        private readonly IArtistDescriptionRepository _repository;
        public ArtistDescriptionService(IArtistDescriptionRepository iRepository)
        {
            _repository = iRepository;
        }
        public IEnumerable<ArtistDescription> GetAllArtistDescriptions()
        {
            return _repository.GetAllArtistDescriptions();
        }

        public ArtistDescription GetArtistDescriptionById(int id)
        {
            return _repository.GetArtistDescriptionById(id);
        }

        public ArtistDescription CreateArtistDescription(ArtistDescription artist)
        {
            _repository.CreateArtistDescription(artist);
            _repository.SaveChanges();

            int createdArtistDescriptionId = artist.ArtistDescriptionId;
            ArtistDescription createdArtistDescription = _repository.GetArtistDescriptionById(createdArtistDescriptionId);

            return createdArtistDescription;
        }

        public void UpdateArtistDescription(ArtistDescription artist)
        {
            _repository.UpdateArtistDescription(artist);
            _repository.SaveChanges();
        }

        public void DeleteArtistDescription(ArtistDescription artist)
        {
            _repository.DeleteArtistDescription(artist);
            _repository.SaveChanges();
        }
    }
}
