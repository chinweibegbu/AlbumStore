using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class ArtistDescription
    {
        public int ArtistDescriptionId { get; set; }
        
        [Required]
        public string Details { get; set; }
    }
}
