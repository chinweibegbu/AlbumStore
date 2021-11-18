using System;
using System.Collections.Generic;
using AlbumStore.DTOs.InternalClasses;

namespace AlbumStore.DTOs
{
    public class AlbumReadDto
    {
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<AlbumGenreReadDto> AlbumGenres { get; set; }
        public decimal Price { get; set; }
        public AlbumArtistReadDto Artist { get; set; }
    }
}
