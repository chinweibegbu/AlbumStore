using AlbumStore.Data;
using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _repository;
        public ArtistService(IArtistRepository iRepository)
        {
            _repository = iRepository;
        }
        public IEnumerable<Artist> GetAllArtists()
        {
            return _repository.GetAllArtists();
        }

        public IEnumerable<Artist> GetAllSoloArtists()
        {
            return _repository.GetAllSoloArtists();
        }

        public Artist GetArtistById(int id)
        {
            return _repository.GetArtistById(id);
        }

        public Artist CreateArtist(Artist artist)
        {
            _repository.CreateArtist(artist);
            _repository.SaveChanges();

            int createdArtistId = artist.ArtistId;
            Artist createdArtist = _repository.GetArtistById(createdArtistId);

            return createdArtist;
        }

        public SoloArtist CreateSoloArtist(SoloArtist soloArtist)
        {
            _repository.CreateArtist(soloArtist);
            _repository.SaveChanges();

            int createdSoloArtistId = soloArtist.ArtistId;
            SoloArtist createdSoloArtist = (SoloArtist)_repository.GetArtistById(createdSoloArtistId);

            return createdSoloArtist;
        }

        public void UpdateArtist(Artist artist)
        {
            _repository.UpdateArtist(artist);
            _repository.SaveChanges();
        }

        public void DeleteArtist(Artist artist)
        {
            _repository.DeleteArtist(artist);
            _repository.SaveChanges();
        }
    }
}
