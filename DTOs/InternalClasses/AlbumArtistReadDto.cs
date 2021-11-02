using AlbumStore.Models;
using System.Collections.Generic;

namespace AlbumStore.DTOs.InternalClasses
{
    public class AlbumArtistReadDto
    {
        public string StageName { get; set; }
        public ArtistDescriptionReadDto ArtistDescription { get; set; }
    }
}
