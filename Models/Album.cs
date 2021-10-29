using System;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AlbumName { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [MaxLength(50)]
        public string Genre { get; set; }
        
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]      // For 2 decimal places
        [Range(0, 9999999999999999.99)]             // For maximum 18 places
        public decimal Price { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
