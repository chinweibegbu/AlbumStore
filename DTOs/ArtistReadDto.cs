using AlbumStore.Models;
using AlbumStore.DTOs.InternalClasses;
using System.Collections.Generic;

namespace AlbumStore.DTOs
{
    public class ArtistReadDto
    {
        public string StageName { get; set; }
        public List<ArtistAlbumReadDto> Albums { get; set; }
        public ArtistDescReadDto ArtistDescription { get; set; }
    }
}
