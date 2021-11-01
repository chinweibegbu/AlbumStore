using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.DTOs
{
    public class ArtistReadDto
    {
        public string StageName { get; set; }
        public List<Album> Albums { get; set; }
        public ArtistDescription ArtistDescription { get; set; }
    }
}
