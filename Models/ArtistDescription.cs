using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class ArtistDescription
    {
        public int ArtistDescriptionId { get; set; }
        
        [Required]
        public string Details { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
    }
}
