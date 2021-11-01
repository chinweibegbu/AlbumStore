using AlbumStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AlbumStore.Data
{
    class SqlArtistDescriptionRepository : IArtistDescriptionRepository
    {
        private readonly AlbumStoreContext _context;

        public SqlArtistDescriptionRepository(AlbumStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<ArtistDescription> GetAllArtistDescriptions()
        {
            return _context.ArtistDescriptions.Include(desc => desc.Artist).ToList();
        }

        public ArtistDescription GetArtistDescriptionById(int id)
        {
            return _context.ArtistDescriptions.Include(desc => desc.Artist).FirstOrDefault(a => a.ArtistDescriptionId == id);
        }

        public void CreateArtistDescription(ArtistDescription artistDescription)
        {
            _context.ArtistDescriptions.Add(artistDescription);
        }

        public void UpdateArtistDescription(ArtistDescription artistDescription)
        {
            // Empty
        }

        public void DeleteArtistDescription(ArtistDescription artistDescription)
        {
            _context.ArtistDescriptions.Remove(artistDescription);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
