using System;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.DTOs
{
    public class ArtistDescriptionWriteDto
    {
        [Required]
        public string Details { get; set; }

        public int ArtistID { get; set; }
    }
}
