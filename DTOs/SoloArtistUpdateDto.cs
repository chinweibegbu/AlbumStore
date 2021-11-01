using System.ComponentModel.DataAnnotations;

namespace AlbumStore.DTOs
{
    public class SoloArtistUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string StageName { get; set; }

        [MaxLength(50)]
        public string Instrument { get; set; }
    }
}
