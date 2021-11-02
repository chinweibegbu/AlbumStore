using System.ComponentModel.DataAnnotations;

namespace AlbumStore.DTOs
{
    public class ArtistUpdateDto
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
    }
}
