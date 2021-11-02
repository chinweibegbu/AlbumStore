using System;

namespace AlbumStore.DTOs.InternalClasses
{
    public class ArtistAlbumReadDto
    {
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
