using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumStore.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string StageName { get; set; }

        public List<Album> Albums { get; set; }
        public ArtistDescription ArtistDescription { get; set; }
    }
}
