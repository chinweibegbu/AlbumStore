using System;
using System.Collections.Generic;

namespace AlbumStore.DTOs.InternalClasses
{
    public class ArtistAlbumReadDto
    {
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<AlbumGenreReadDto> AlbumGenres { get; set; }
        public decimal Price { get; set; }
    }
}
