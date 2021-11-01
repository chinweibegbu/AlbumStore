using System.ComponentModel.DataAnnotations;

namespace AlbumStore.DTOs
{
    public class ArtistDescriptionUpdateDto
    {
        [Required]
        public string Details { get; set; }

        public int ArtistID { get; set; }
    }
}
